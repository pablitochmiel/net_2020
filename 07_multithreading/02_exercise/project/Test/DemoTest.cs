using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Utils;
using Xunit;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class DemoTest
    {
        private static Demo GetDemo(int[] data)
        {
            return new Demo(data);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] {0, Array.Empty<int>()};
            yield return new object[] {1, new[] {1}};
            yield return new object[] {2, new[] {1, 1}};
            yield return new object[] {45, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}};
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Sum(int expected, int[] data)
        {
            Assert.Equal(expected, GetDemo(data).Sum());
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void SumForeach(int expected, int[] data)
        {
            Assert.Equal(expected, GetDemo(data).SumForeach());
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void SumLinq(int expected, int[] data)
        {
            Assert.Equal(expected, GetDemo(data).SumLinq());
        }

        public static IEnumerable<object[]> GetDataAndThreads()
        {
            return from threads in new[] {2, 4, 8}
                from data in GetData()
                select new[] {data[0], data[1], threads};
        }

        [Theory]
        [MemberData(nameof(GetDataAndThreads))]
        public void SumThreadsInterlocked(int expected, int[] data, int threads)
        {
            Assert.Equal(expected, GetDemo(data).SumThreadsInterlocked(threads));
        }

        [Theory]
        [MemberData(nameof(GetDataAndThreads))]
        public void SumThreads(int expected, int[] data, int threads)
        {
            Assert.Equal(expected, GetDemo(data).SumThreads(threads));
        }

        [Theory]
        [MemberData(nameof(GetDataAndThreads))]
        public void SumPoolThreads(int expected, int[] data, int threads)
        {
            Assert.Equal(expected, GetDemo(data).SumPoolThreads(threads));
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void SumTpl(int expected, int[] data)
        {
            Assert.Equal(expected, GetDemo(data).SumTpl());
        }
    }
}