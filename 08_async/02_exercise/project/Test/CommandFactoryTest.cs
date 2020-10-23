using System;
using System.Threading;
using Utils;
using Xunit;

namespace Test
{
    public class CommandFactoryTest
    {
        [Fact]
        public void AccessCancellationTokenSource()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            Assert.Equal(source, factory.CancellationTokenSource);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void DelayedPrintCommand()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            var command = Assert.IsType<DelayedPrintCommand>(factory.Create("print"));
            Assert.Equal("Hello!", command.Message);
            Assert.Equal(5000, command.Delay);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void DelayedPrintCommandWithMessage()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            var command = Assert.IsType<DelayedPrintCommand>(factory.Create("print", "test"));
            Assert.Equal("test", command.Message);
            Assert.Equal(5000, command.Delay);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void DelayedPrintCommandWithMessageAndDelay()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            var command = Assert.IsType<DelayedPrintCommand>(factory.Create("print", "test", "1000"));
            Assert.Equal("test", command.Message);
            Assert.Equal(1000, command.Delay);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void ExitCancelsAndReturnsNullCommand()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            Assert.IsType<NullCommand>(factory.Create("exit"));
            Assert.True(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void InputCommand()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            Assert.IsType<InputCommand>(factory.Create("input"));
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void NullCommandWhenNoArgumentsAreProvided()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            Assert.IsType<NullCommand>(factory.Create(""));
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void SizeCommand()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            var command = Assert.IsType<SizeCommand>(factory.Create("size"));
            Assert.Equal(new Uri("https://google.com"), command.Uri);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }

        [Fact]
        public void SizeCommandWithUri()
        {
            using var source = new CancellationTokenSource();
            var factory = new CommandFactory(source);

            var command = Assert.IsType<SizeCommand>(factory.Create("size", "http://gwizdz.pl"));
            Assert.Equal(new Uri("http://gwizdz.pl"), command.Uri);
            Assert.False(source.Token.IsCancellationRequested);
            
            source.Dispose();
        }
    }
}