using System.Threading;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class DelayedPrintCommandTest
    {
        [Fact]
        public void HasName()
        {
            const string message = "message";
            const int delay = 5000;

            var mock = new Mock<ITime>();

            var delayedPrintCommand = new DelayedPrintCommand(message, delay, mock.Object);

            Assert.Equal(delay, delayedPrintCommand.Delay);
            Assert.Equal(message, delayedPrintCommand.Message);
            Assert.Equal($"delayed print '{message}' in 5000 ms", delayedPrintCommand.Name);
        }

        [Fact]
        public async void ReturnsMessageAfterFiveSeconds()
        {
            const string message = "message";
            const int delay = 5000;

            var mock = new Mock<ITime>();
            mock.Setup(t => t.Delay(delay, CancellationToken.None));

            var command = new DelayedPrintCommand(message, delay, mock.Object);
            Assert.Equal(message, await command.RunAsync(CancellationToken.None));
        }
    }
}