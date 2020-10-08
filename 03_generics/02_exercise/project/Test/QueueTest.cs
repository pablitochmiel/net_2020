using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class QueueTest
    {
        [Fact]
        public void QueueOfIntBasicOperations()
        {
            // TODO: ...

            Assert.Empty(queue);

            // TODO: ...

            Assert.Equal(3, queue.Count);

            int Next()
            {
                // TODO: ...
            }

            Assert.Equal(3, queue.Count);
            Assert.Equal(1, Next());
            Assert.Equal(2, Next());
            Assert.Equal(3, Next());
            Assert.Empty(queue);
        }

        [Fact]
        public void QueueOfIntCheckNextValueWithoutRemovingIt()
        {
            // TODO: ...

            Assert.Empty(queue);
            
            // TODO: ...

            Assert.Equal(2, queue.Count);

            // TODO: ...

            Assert.Equal(1, value);

            int Next()
            {
                // TODO: ...
            }

            Assert.Equal(1, Next());
            Assert.Equal(2, Next());
            
            Assert.Empty(queue);
        }
    }
}