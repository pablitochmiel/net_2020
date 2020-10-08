using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class StackTest
    {
        [Fact]
        public void StackOfIntBasicOperations()
        {
            // TODO: ...

            Assert.Empty(stack);
            
            // TODO: ...

            Assert.Equal(3, stack.Count);
            
            int Next()
            {
                // TODO: ...
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