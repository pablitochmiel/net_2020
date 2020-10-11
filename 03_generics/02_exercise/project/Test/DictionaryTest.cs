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
            var dictionary = new Dictionary<int, int> {{1, 10}};

            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            dictionary.Remove(1);
            dictionary.Add(1,20);

            Assert.Single(dictionary);
            Assert.Equal(20, dictionary[1]);
        }

        [Fact]
        public void DictionaryOfInToIntRemoveValues()
        {
            var dictionary = new Dictionary<int,int>{{1,2},{2,3},{3,4}};
            
            Assert.Equal(3, dictionary.Count);
            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
            Assert.True(dictionary.ContainsKey(3));

            dictionary.Remove(2);
            dictionary.Remove(3);

            Assert.Single(dictionary);
            Assert.True(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(2));
            Assert.False(dictionary.ContainsKey(3));
        }

        [Fact]
        public void DictionaryOfInToIntTryGetValue()
        {
            var dictionary = new Dictionary<int, int> {{1, 10}};

            Assert.Single(dictionary);
            Assert.Equal(10, dictionary[1]);

            var value = dictionary[1];
            var hasValue = dictionary.ContainsValue(10);

            Assert.True(hasValue);
            Assert.Equal(10, value);
            
            Assert.Single(dictionary);
        }

        [Fact]
        public void DictionaryOfIntToIntCanBeCreatedInOneLine()
        {
            var dictionary = new Dictionary<int,int>{{1,2},{3,4}};

            Assert.Equal(2, dictionary.Count);
            Assert.Equal(2, dictionary[1]);
            Assert.Equal(4, dictionary[3]);
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWheKeyNotInDictionary()
        {
            var dictionary=new Dictionary<string,string>{{"A","B"}};

            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AccessElement()
            {
                var unused = dictionary["C"];
            }

            Assert.Throws<KeyNotFoundException>(AccessElement);

            dictionary.Add("C","A");
            
            Assert.Equal(2, dictionary.Count);

            AccessElement();
        }

        [Fact]
        public void DictionaryOfStringToStringThrowsWhenAddedElementExists()
        {
            var dictionary=new Dictionary<string,string>{{"A","B"}};

            Assert.Single(dictionary);
            Assert.Equal("B", dictionary["A"]);

            void AddElement()
            {
                dictionary.Add("A","C");
            }

            Assert.Throws<ArgumentException>(AddElement);

            dictionary.Remove("A");

            Assert.Empty(dictionary);

            AddElement();
            
            Assert.Single(dictionary);
            Assert.Equal("C", dictionary["A"]);
        }
    }
}