using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class LinkedListTest
    {
        [Fact]
        public void LinkedListOdIntBasicOperations()
        {
            var linkedList=new LinkedList<int>();
            linkedList.AddFirst(1);

            Assert.Single(linkedList);
            Assert.Equal(1, linkedList.First?.Value);

            linkedList.AddFirst(2);
            
            Assert.Equal(2, linkedList.Count);
            Assert.Equal(2, linkedList.First!.Value);
            Assert.Equal(1, linkedList.Last!.Value);

            linkedList.AddAfter(linkedList.First!, 4);

            Assert.Equal(3, linkedList.Count);
            Assert.Equal(2, linkedList.First!.Value);
            Assert.Equal(4, linkedList.First!.Next!.Value);
            Assert.Equal(1, linkedList.Last!.Value);
            Assert.Equal(4, linkedList.Last!.Previous!.Value);
        }
    }
}