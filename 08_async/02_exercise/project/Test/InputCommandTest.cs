using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class InputCommandTest
    {
        [Fact]
        public void ContinuationsNullCancellationTokenSource()
        {
            Assert.Throws<ArgumentNullException>(() => new InputCommand().Continuations("x", null!).ToArray());
        }

        [Fact]
        public void ContinuationsNullResult()
        {
            Assert.Throws<ArgumentNullException>(() => new InputCommand().Continuations(null!, null!).ToArray());
        }

        [Fact]
        public void CreatesContinuations()
        {
            var inputCommand = new InputCommand();
            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandOneMock = new Mock<Command>();
            var commandTwoMock = new Mock<Command>();

            var commands = new[] {commandOneMock.Object, commandTwoMock.Object};

            commandFactoryMock.Setup(f => f.Create("x", "y", "z")).Returns(commandOneMock.Object).Verifiable();
            commandFactoryMock.Setup(f => f.Create("input")).Returns(commandTwoMock.Object).Verifiable();

            var result = inputCommand.Continuations("x y z", commandFactoryMock.Object);
            Assert.Equal(commands, result);

            commandFactoryMock.Verify();
        }

        [Fact]
        public void HasName()
        {
            var inputCommand = new InputCommand();

            Assert.Equal("input", inputCommand.Name);
        }

        [Fact]
        public async Task ReadsInputFromConsole()
        {
            var textReaderMock = new Mock<TextReader>();
            Console.SetIn(textReaderMock.Object);

            textReaderMock.Setup(tr => tr.ReadLine()).Returns("foo");

            var inputCommand = new InputCommand();

            var task = inputCommand.RunAsync(CancellationToken.None);

            Assert.Equal("foo", await task);
        }
    }
}