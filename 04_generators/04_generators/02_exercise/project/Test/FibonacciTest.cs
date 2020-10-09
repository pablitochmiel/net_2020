using System;
using System.Collections.Generic;
using Utils;
using Xunit;

namespace Test
{
    public class FibonacciTest
    {
        [Fact]
        public void FibonacciNumbersAreReturnedAsEnumerableOfInt()
        {
            var fibonacci = new Fibonacci();
            Assert.IsAssignableFrom<IEnumerable<int>>(fibonacci.Numbers());
        }

        [Fact]
        public void ProducesFibonacciNumbers()
        {
            var fibonacci = new Fibonacci();

            var expected = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21};
            var actual = new List<int>();

            foreach (var number in fibonacci.Numbers())
            {
                if (actual.Count == expected.Count)
                    break;

                actual.Add(number);
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsOnFortyFourthValueBecauseIntIsToSmallToHoldMore()
        {
            var fibonacci = new Fibonacci();
            var numbers = fibonacci.Numbers();
            var enumerator = numbers.GetEnumerator();

            for (var i = 0; i <= 43; i++)
                enumerator.MoveNext();

            Assert.Throws<IndexOutOfRangeException>(() => enumerator.MoveNext());

            enumerator.Dispose();
        }
    }
}