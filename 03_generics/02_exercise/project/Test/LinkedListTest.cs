using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class LinkedListTest
    {
        [Fact]
        public void LinkedListOdIntBasicOperations()
        {
            // TODO: ...

            Assert.Single(linkedList);
            Assert.Equal(1, linkedList.First?.Value);

            // TODO: ...

            Assert.Equal(2, linkedList.Count);
            Assert.Equal(2, linkedList.First!.Value);
            Assert.Equal(1, linkedList.Last!.Value);

            // TODO: ...

            Assert.Equal(3, linkedList.Count);
            Assert.Equal(2, linkedList.First!.Value);
            Assert.Equal(4, linkedList.First!.Next!.Value);
            Assert.Equal(1, linkedList.Last!.Value);
            Assert.Equal(4, linkedList.Last!.Previous!.Value);
        }
    }
}