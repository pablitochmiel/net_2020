using System.Threading;
using Utils;
using Xunit;

namespace Test
{
    public class NullCommandTest
    {
        [Fact(Timeout = 10)]
        public void FinishesImmediately()
        {
            var command = new NullCommand();
            Assert.Equal("null", command.RunAsync(CancellationToken.None).Result);
        }

        [Fact]
        public void HasName()
        {
            var nullCommand = new NullCommand();

            Assert.Equal("null", nullCommand.Name);
        }
    }
}