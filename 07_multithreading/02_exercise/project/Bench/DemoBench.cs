using System.Diagnostics.CodeAnalysis;
using Microsoft.Xunit.Performance;
using Utils;
using Xunit;

namespace Bench
{
    [ExcludeFromCodeCoverage]
    public class DemoBench
    {
        private static Demo GetDemo()
        {
            var data = new int[10000000];

            for (var i = 0; i < data.Length; i++)
                data[i] = 1;

            return new Demo(data);
        }

        [Benchmark]
        private void Sum()
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.Sum(); });
        }

        [Benchmark]
        private void SumForeach()
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumForeach(); });
        }

        [Benchmark]
        private void SumLinq()
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumLinq(); });
        }

        [Benchmark]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        private void SumThreadsInterlocked(int threads)
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumThreadsInterlocked(threads); });
        }

        [Benchmark]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        private void SumThreads(int threads)
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumThreads(threads); });
        }

        [Benchmark]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        private void SumPoolThreads(int threads)
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumPoolThreads(threads); });
        }

        [Benchmark]
        private void SumTpl()
        {
            var demo = GetDemo();
            Benchmark.Iterate(() => { demo.SumTpl(); });
        }
    }
}