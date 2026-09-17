# Benchmark Results — string vs StringBuilder

## Environment

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9457/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-12650H 2.30GHz, 1 CPU, 16 logical and 10 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.2, 9.0.225.6610), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 9.0.2 (9.0.2, 9.0.225.6610), X64 RyuJIT x86-64-v3
```

Both benchmark methods append the literal `"Session"` to a growing text
`Iterations` times, so the work is equivalent. `MemoryDiagnoser` is enabled.

## Results

| Method                     | Iterations | Mean                | Error             | StdDev            | Allocated      |
|--------------------------- |----------- |--------------------:|------------------:|------------------:|---------------:|
| StringConcatenation        | 100        |          2,815.7 ns |          28.27 ns |          54.46 ns |       71.45 KB |
| StringBuilderConcatenation | 100        |            288.8 ns |           3.60 ns |           3.36 ns |        3.88 KB |
| StringConcatenation        | 1000       |        230,948.6 ns |       3,116.30 ns |       2,433.00 ns |     6867.15 KB |
| StringBuilderConcatenation | 1000       |          3,860.0 ns |         306.40 ns |         903.43 ns |        30.4 KB |
| StringConcatenation        | 10000      |     90,841,736.7 ns |   1,785,237.43 ns |   2,672,059.54 ns |   683951.52 KB |
| StringBuilderConcatenation | 10000      |        110,658.3 ns |         595.46 ns |         556.99 ns |      279.02 KB |
| StringConcatenation        | 100000     | 12,616,366,360.0 ns | 245,511,593.69 ns | 229,651,697.17 ns | 68364572.45 KB |
| StringBuilderConcatenation | 100000     |        859,508.4 ns |      52,703.63 ns |     153,738.98 ns |     2749.69 KB |

### Summary

| Iterations | string        | StringBuilder | StringBuilder is faster by |
|----------- |-------------- |-------------- |--------------------------- |
| 100        | 2.82 µs       | 0.29 µs       | ~10×                       |
| 1,000      | 231 µs        | 3.86 µs       | ~60×                       |
| 10,000     | 90.8 ms       | 0.11 ms       | ~820×                      |
| 100,000    | 12.62 s       | 0.86 ms       | ~14,680×                   |

## Analysis

### 1. Which approach was faster with 100 iterations?

`StringBuilderConcatenation`, at 288.8 ns against 2,815.7 ns — roughly ten times
faster. The gap is already visible at this size, but in absolute terms both run
in microseconds, so the difference would not be noticeable in a real workload.

### 2. Which approach was faster with 100,000 iterations?

`StringBuilderConcatenation`, and the gap is enormous: 859,508 ns (0.86 ms)
against 12,616,366,360 ns (12.6 seconds). That is about 14,680 times faster.

### 3. Which approach allocated more memory?

String concatenation allocated far more at every size. At 100,000 iterations it
allocated 68,364,572 KB — roughly 65 GB — while `StringBuilder` allocated
2,749 KB (about 2.7 MB). That is a factor of about 24,900.

The `Gen0`, `Gen1` and `Gen2` columns show the consequence: string
concatenation triggered around 8.9 million Gen0 collections per 1000 operations
and, unlike the smaller runs, pushed objects all the way into Gen2. Most of the
12.6 seconds is garbage collection pressure rather than the copying itself.

### 4. What happened to string concatenation performance as the loop size increased?

It degraded quadratically. Each 10× increase in loop size multiplied the time by
roughly 100×:

| Iterations | Mean     | Change vs. previous |
|----------- |--------- |-------------------- |
| 100        | 2.82 µs  | —                   |
| 1,000      | 231 µs   | ×82                 |
| 10,000     | 90.8 ms  | ×393                |
| 100,000    | 12.62 s  | ×139                |

`StringBuilder` grew close to linearly over the same range: 0.29 µs → 3.86 µs →
0.11 ms → 0.86 ms, which is what you expect when the cost per append stays
roughly constant.

### 5. Why does repeated string concatenation create additional allocations?

Strings in .NET are immutable — no method can change the contents of an existing
string. Every `result += "Session"` therefore has to:

1. allocate a new string sized to hold the old contents plus the new text
2. copy the entire old string into it
3. append the new text
4. leave the old string for the garbage collector

So N appends allocate N intermediate strings, and each one copies everything
accumulated so far. At iteration 100,000 the loop is copying a string about
700,000 characters long, which is why the total allocation reaches 65 GB even
though the final result is under 1 MB.

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` keeps an internal mutable buffer. `Append` writes into the free
space of that buffer with no copying and no new object. When the buffer fills up
it allocates a larger one (roughly doubling) and copies across — but that happens
a logarithmic number of times, not once per append. Growing from empty to 700,000
characters takes on the order of 17 resizes rather than 100,000 allocations.

The only full copy happens once, at the end, in `ToString()`.

### 7. Is StringBuilder always better than normal string operations? Explain.

No.

At 100 iterations the absolute difference is 2.5 microseconds — irrelevant in
almost any real program, and not worth the extra code. For a handful of pieces,
plain concatenation or string interpolation is clearer and carries no object
allocation for the builder itself.

Concatenation of literals is also resolved at compile time, so `"a" + "b" + "c"`
becomes a single string with zero runtime cost — using `StringBuilder` there
would be strictly slower.

`StringBuilder` becomes the right choice when appends happen in a loop, when the
number of appends is large or unknown ahead of time, or when the text is built up
in many separate steps. The results above show the crossover is not about which
is "faster" in principle but about how the cost scales: below a few hundred
appends the choice barely matters, and past a few thousand it dominates
everything else.