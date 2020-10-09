using System.Collections;
using System.Collections.Generic;
//using Utils;
using Xunit;

namespace Test
{
    public class CollectionTest
    {/*
        [Fact]
        public void CapacityByDefaultGrowsByTwoStartingFromOne()
        {
            var collection = new Collection<int>();

            Assert.Equal(2, collection.Factor);

            Assert.Equal(0, collection.Count);
            Assert.Equal(1, collection.Capacity);

            collection.Add(1);

            Assert.Equal(1, collection.Count);
            Assert.Equal(1, collection.Capacity);

            collection.Add(2);

            Assert.Equal(2, collection.Count);
            Assert.Equal(2, collection.Capacity);

            collection.Add(3);

            Assert.Equal(3, collection.Count);
            Assert.Equal(4, collection.Capacity);

            collection.Add(4);

            Assert.Equal(4, collection.Count);
            Assert.Equal(4, collection.Capacity);

            collection.Add(5);

            Assert.Equal(5, collection.Count);
            Assert.Equal(8, collection.Capacity);
        }

        [Fact]
        public void AllocationSizeGrowingFactorCanBeConfigured()
        {
            var collection = new Collection<int>(2, 3);

            Assert.Equal(3, collection.Factor);

            Assert.Equal(0, collection.Count);
            Assert.Equal(2, collection.Capacity);

            collection.Add(1);
            collection.Add(2);

            Assert.Equal(2, collection.Count);
            Assert.Equal(2, collection.Capacity);

            collection.Add(3);

            Assert.Equal(3, collection.Count);
            Assert.Equal(6, collection.Capacity);
        }

        [Fact]
        public void CollectionOfIntCanBeUsedAsEnumerable()
        {
            IEnumerable enumerable = new Collection<int> {1};
            Assert.Single(enumerable);
        }

        [Fact]
        public void CollectionOfIntCanBeUsedAsTypedEnumerable()
        {
            IEnumerable<int> typedEnumerable = new Collection<int> {1};
            Assert.Single(typedEnumerable);
        }

        [Fact]
        public void CollectionOfIntCanBeUsedInForeach()
        {
            var collection = new Collection<int> {1, 2, 3, 4};

            var count = 0;
            var sum = 0;

            foreach (var element in collection)
            {
                count++;
                sum += element;
            }

            Assert.Equal(4, count);
            Assert.Equal(10, sum);
        }

        [Fact]
        public void CollectionOfIntCanCanBeCreatedInOneLine()
        {
            var collection = new Collection<int> {1, 2, 3, 4};

            Assert.Equal(4, collection.Count);
            Assert.Equal(1, collection[0]);
            Assert.Equal(2, collection[1]);
            Assert.Equal(3, collection[2]);
            Assert.Equal(4, collection[3]);
        }

        [Fact]
        public void InitialCapacityCanBeConfigured()
        {
            var collection = new Collection<int>(4);

            Assert.Equal(0, collection.Count);
            Assert.Equal(4, collection.Capacity);
        }*/
    }
}