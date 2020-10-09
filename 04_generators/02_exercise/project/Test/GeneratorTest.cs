using Utils;
using Xunit;

namespace Test
{
    public class GeneratorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1, "Hello", "World")]
        [InlineData(3, "Hello", "World", "Hello", "World", "Hello", "World")]
        public void SimpleAddition(int times, params string[] words)
        {
            var generator = new Generator(times);

            var index = 0;
            foreach (var word in generator.Words())
            {
                Assert.Equal(words[index++], word);
            }
        }
    }
}