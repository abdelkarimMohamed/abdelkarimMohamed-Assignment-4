# LeetCode

## Profile

https://leetcode.com/u/Karim_Ali93/

---

## 1. Valid Anagram

- **Problem:** Valid Anagram (LeetCode 242)
- **URL:** https://leetcode.com/problems/valid-anagram
- **Status:** Accepted
- **Submission:** https://leetcode.com/problems/valid-anagram/submissions/2145034956/
- **Screenshot:** [valid-anagram-accepted.png](images/valid-anagram-accepted.png
)

### Approach

Count how many times each letter appears. A fixed `int[26]` array is used as the
counter, indexed by `c - 'a'`. The first string increments its letters and the
second decrements them in the same pass. If every counter ends at zero, both
strings contain the same letters with the same frequencies.

Different lengths are rejected immediately — two strings of different lengths can
never be anagrams.

- **Time:** O(n) — one pass over the strings, plus a fixed 26-slot check
- **Space:** O(1) — the counter array is always 26 slots regardless of input size

---

## 2. Greatest Common Divisor of Strings

- **Problem:** Greatest Common Divisor of Strings (LeetCode 1071)
- **URL:** https://leetcode.com/problems/greatest-common-divisor-of-strings
- **Status:** Accepted
- **Submission:** https://leetcode.com/problems/greatest-common-divisor-of-strings/submissions/2145028766/
- **Screenshot:** [gcd-of-strings-accepted.png](images/gcd-of-strings-accepted.png)

### Approach

<هتملاها بعد Part 27>