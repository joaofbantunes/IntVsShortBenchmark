using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace CodingMilitia.IntVsShortBenchmark.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IntVsShort>(
                ManualConfig.Create(DefaultConfig.Instance).With(MemoryDiagnoser.Default)
            );
        }
    }

    public class IntVsShort
    {
        private const short Iterations = short.MaxValue;

        [Benchmark(Baseline = true)]
        public void ForUsingInt()
        {
            for (int i = 0; i < Iterations; ++i)
            {
            }
        }

        [Benchmark]
        public void ForUsingShort()
        {
            for (short i = 0; i < Iterations; ++i)
            {
            }
        }
    }
}