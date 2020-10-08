using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class DictionaryTest
    {
        [Fact]
        public void DictionaryOfInToIntChangeExistingValue()
        {
            // TODO: ...

            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            // TODO: ...

            Assert.Single(dictionary);
            Assert.Equal(20, dictionary[1]);
        }

        [Fact]
        public void DictionaryOfInToIntRemoveValues()
        {
            // TODO: ...

            Assert.Equal(3, dictionary.Count);
            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
            Assert.True(dictionary.ContainsKey(3));

            // TODO: ...

            Assert.Single(dictionary);
            Assert.True(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(2));
            Assert.False(dictionary.ContainsKey(3));
        }

        [Fact]
        public void DictionaryOfInToIntTryGetValue()
        {
            // TODO: ...

            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            // TODO: ...

            Assert.True(hasValue);
            Assert.Equal(10, value);
            
            Assert.Single(dictionary);
        }

        [Fact]
        public void DictionaryOfIntToIntCanBeCreatedInOneLine()
        {
            // TODO: ...

            Assert.Equal(2, dictionary.Count);
            Assert.Equal(2, dictionary[1]);
            Assert.Equal(4, dictionary[3]);
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWheKeyNotInDictionary()
        {
            // TODO: ...

            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AccessElement()
            {
                // TODO: ...
            }

            Assert.Throws<KeyNotFoundException>(AccessElement);

            // TODO: ...
            
            Assert.Equal(2, dictionary.Count);

            AccessElement();
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWhenAddedElementExists()
        {
            // TODO: ...

            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AddElement()
            {
                // TODO: ...
            }

            Assert.Throws<ArgumentException>(AddElement);

            // TODO: ...

            Assert.Empty(dictionary);

            AddElement();
            
            Assert.Single(dictionary);
            Assert.Equal("C", dictionary["A"]);
        }
    }
}