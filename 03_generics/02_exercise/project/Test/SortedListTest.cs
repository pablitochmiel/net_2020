using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class SortedListTest
    {
        // TODO: ReversedComparer class...

        [Fact]
        public void SortedListOfIntToStringIsSortedByKey()
        {
            // TODO: ...

            Assert.Equal(3, list.Count);

            Assert.Equal("C", list[0]);
            Assert.Equal("A", list[1]);
            Assert.Equal("B", list[2]);

            Assert.Equal(0, list.Keys[0]);
            Assert.Equal(1, list.Keys[1]);
            Assert.Equal(2, list.Keys[2]);

            Assert.Equal("C", list.Values[0]);
            Assert.Equal("A", list.Values[1]);
            Assert.Equal("B", list.Values[2]);
        }

        [Fact]
        public void SortedListOfIntToStringWithCustomComparer()
        {
            // TODO: ...

            Assert.IsType<ReversedComparer>(list.Comparer);
            
            Assert.Equal(3, list.Count);

            Assert.Equal("C", list[0]);
            Assert.Equal("A", list[1]);
            Assert.Equal("B", list[2]);

            Assert.Equal(2, list.Keys[0]);
            Assert.Equal(1, list.Keys[1]);
            Assert.Equal(0, list.Keys[2]);

            Assert.Equal("B", list.Values[0]);
            Assert.Equal("A", list.Values[1]);
            Assert.Equal("C", list.Values[2]);
        }
    }
}