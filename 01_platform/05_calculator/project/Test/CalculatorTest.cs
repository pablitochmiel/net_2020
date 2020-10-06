using Xunit;
using Utils;

namespace Test
{
    public class CalculatorTest
    {
        [Fact]
        public void Add()
        {
            var c = new Calculator(3.4, 5.2);
            Assert.Equal(8.6,c.Add(),2);
        }
        
        [Fact]
        public void Sub()
        {
            var c = new Calculator(3.4, 5.2);
            Assert.Equal(-1.8,c.Sub(),2);
        }
        
        [Fact]
        public void Mul()
        {
            var c = new Calculator(3.4, 5.2);
            Assert.Equal(17.68,c.Mul(),2);
        }
        
        [Fact]
        public void Div()
        {
            var c = new Calculator(10.4, 5.2);
            Assert.Equal(2,c.Div(),2);
        }
    }
}