using System.Text;
using BenchmarkDotNet.Attributes;

namespace AcademyScheduleAnalyzer.Benchmarks;

[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";

        for (int i = 0; i < Iterations; i++)
        {
            result += "Session";
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            builder.Append("Session");
        }

        return builder.ToString();
    }
}