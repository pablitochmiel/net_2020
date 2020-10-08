using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class ListTest
    {
        [Fact]
        public void ListOfIntHasSometimesHigherCapacityThanCount()
        {
            // TODO: ...

            Assert.Single(list);
            Assert.Equal(4, list.Capacity);
        }

        [Fact]
        public void ListOfIntHasSometimesTheSameSizeAndCapacity()
        {
            // TODO: ...

            Assert.Equal(4, listOne.Count);
            Assert.Equal(4, listOne.Capacity);

            // TODO: ...

            Assert.Equal(2, listTwo.Count);
            Assert.Equal(4, listTwo.Capacity);
        }

        [Fact]
        public void ListOfIntSometimesGrowsCapacityAfterAdd()
        {
            // TODO: ...

            Assert.Equal(2, list.Count);
            Assert.Equal(4, list.Capacity);

            // TODO: ...

            Assert.Equal(3, list.Count);
            Assert.Equal(4, list.Capacity);

            // TODO: ...

            Assert.Equal(4, list.Count);
            Assert.Equal(4, list.Capacity);

            // TODO: ...

            Assert.Equal(5, list.Count);
            Assert.Equal(8, list.Capacity);
        }

        [Fact]
        public void ListOfStringCanBeCreatedInOneLine()
        {
            // TODO: ...

            Assert.Equal(3, list.Count);
            Assert.Equal("Foo", list[0]);
            Assert.Equal("Bar", list[1]);
            Assert.Equal("Baz", list[2]);
        }
        
        [Fact]
        public void ListOfStringCanBeSortedWithCustomComparators()
        {
            // TODO: ...
            
            Assert.Equal(7, list.Count);
            Assert.Equal("EC", list[0]);
            Assert.Equal("FB", list[1]);
            Assert.Equal("GA", list[2]);
            Assert.Equal("AG", list[3]);
            Assert.Equal("BF", list[4]);
            Assert.Equal("CE", list[5]);
            Assert.Equal("DD", list[6]);
            
            // TODO: ...
            
            Assert.Equal(7, list.Count);
            Assert.Equal("GA", list[0]);
            Assert.Equal("FB", list[1]);
            Assert.Equal("EC", list[2]);
            Assert.Equal("DD", list[3]);
            Assert.Equal("CE", list[4]);
            Assert.Equal("BF", list[5]);
            Assert.Equal("AG", list[6]);
            
            // TODO: ...
            
            Assert.Equal(7, list.Count);
            Assert.Equal("AG", list[0]);
            Assert.Equal("BF", list[1]);
            Assert.Equal("CE", list[2]);
            Assert.Equal("DD", list[3]);
            Assert.Equal("EC", list[4]);
            Assert.Equal("FB", list[5]);
            Assert.Equal("GA", list[6]);
        }
    }
}