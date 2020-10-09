using Utils;
using Xunit;

namespace Test
{
    public class RangeFibonacciTest
    {
        [Fact]
        public void FirstFibonacciNumberIsZeroAndSecondOne()
        {
            var rangeFibonacci = new RangeFibonacci();

            static void N0(int n) => Assert.Equal(0, n);
            static void N1(int n) => Assert.Equal(1, n);

            Assert.Collection(rangeFibonacci.Numbers(), N0, N1);
        }

        [Fact]
        public void CanCalculateNonTrivialNumbersFromTwoToFive()
        {
            var rangeFibonacci = new RangeFibonacci(2, stop: 5);

            static void N2(int n) => Assert.Equal(1, n);
            static void N3(int n) => Assert.Equal(2, n);
            static void N4(int n) => Assert.Equal(3, n);
            static void N5(int n) => Assert.Equal(5, n);

            Assert.Collection(rangeFibonacci.Numbers(), N2, N3, N4, N5);
        }

        [Fact]
        public void CanCalculateNonTrivialNumbersFiveToFifteenWithStepTwo()
        {
            var rangeFibonacci = new RangeFibonacci(5, 2, 15);

            static void N5(int n) => Assert.Equal(5, n);
            static void N7(int n) => Assert.Equal(13, n);
            static void N9(int n) => Assert.Equal(34, n);
            static void N11(int n) => Assert.Equal(89, n);
            static void N13(int n) => Assert.Equal(233, n);
            static void N15(int n) => Assert.Equal(610, n);

            Assert.Collection(rangeFibonacci.Numbers(), N5, N7, N9, N11, N13, N15);
        }
    }
}