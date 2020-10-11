using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class QueueTest
    {
        [Fact]
        public void QueueOfIntBasicOperations()
        {
            var queue=new Queue<int>();

            Assert.Empty(queue);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);

            int Next()
            {
                return queue.Dequeue();
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
            var queue=new Queue<int>();

            Assert.Empty(queue);
            
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.Equal(2, queue.Count);

            var value = queue.Peek();

            Assert.Equal(1, value);

            int Next()
            {
                return queue.Dequeue();
            }

            Assert.Equal(1, Next());
            Assert.Equal(2, Next());
            
            Assert.Empty(queue);
        }
    }
}