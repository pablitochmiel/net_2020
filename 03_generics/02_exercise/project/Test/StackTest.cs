using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class StackTest
    {
        [Fact]
        public void StackOfIntBasicOperations()
        {
            var stack=new Stack<int>();

            Assert.Empty(stack);
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Count);
            
            int Next()
            {
                return stack.Pop();
            }

            Assert.Equal(3, stack.Count);

            Assert.Equal(3, Next());
            Assert.Equal(2, stack.Count);

            Assert.Equal(2, Next());
            Assert.Single(stack);

            Assert.Equal(1, Next());
            Assert.Empty(stack);
        }
    }
}