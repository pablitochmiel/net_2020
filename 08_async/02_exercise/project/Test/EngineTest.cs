using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public sealed class EngineTest : IDisposable
    {
        public EngineTest()
        {
            _source = new CancellationTokenSource();
            _textWriterMock = new Mock<TextWriter>();
            _factoryMock = new Mock<ICommandFactory>(MockBehavior.Strict);
            _inputCommandMock = new Mock<Command>(MockBehavior.Strict);
            _continuationCommandMock = new Mock<Command>(MockBehavior.Strict);
            _continuationCommands = new[] {_continuationCommandMock.Object};
            _noContinuationCommands = Array.Empty<Command>();
        }

        public void Dispose()
        {
            _source.Dispose();
        }

        private readonly CancellationTokenSource _source;
        private readonly Mock<TextWriter> _textWriterMock;
        private readonly Mock<ICommandFactory> _factoryMock;
        private readonly Mock<Command> _inputCommandMock;
        private readonly Mock<Command> _continuationCommandMock;
        private readonly Command[] _continuationCommands;
        private readonly Command[] _noContinuationCommands;

        [Fact]
        public async Task CanceledTask()
        {
            Console.SetOut(_textWriterMock.Object);

            _factoryMock.Setup(f => f.Create("input")).Returns(_inputCommandMock.Object);
            _factoryMock.Setup(f => f.CancellationTokenSource).Returns(_source);

            _inputCommandMock.Setup(c => c.RunAsync(_source.Token)).ReturnsAsync("result");
            _inputCommandMock.Setup(c => c.Continuations("result", _factoryMock.Object))
                .Callback(() => throw new TaskCanceledException());
            _inputCommandMock.Setup(ic => ic.Name).Returns("name");

            var order = 0;
            
            _textWriterMock.Setup(tw => tw.WriteLine("[+] name")).Callback(() => Assert.Equal(0, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[X] name")).Callback(() => Assert.Equal(1, order++));

            var engine = new Engine(_factoryMock.Object);
            await engine.RunAsync();

            _textWriterMock.VerifyAll();
        }

        [Fact]
        public async Task ContinuationsAfterInput()
        {
            Console.SetOut(_textWriterMock.Object);

            _factoryMock.Setup(f => f.Create("input")).Returns(_inputCommandMock.Object);
            _factoryMock.Setup(f => f.CancellationTokenSource).Returns(_source);

            _inputCommandMock.Setup(ic => ic.RunAsync(_source.Token)).ReturnsAsync("inputResult");
            _inputCommandMock.Setup(ic => ic.Continuations("inputResult", _factoryMock.Object))
                .Returns(_continuationCommands);
            _inputCommandMock.Setup(ic => ic.Name).Returns("inputName");

            _continuationCommandMock.Setup(cc => cc.RunAsync(_source.Token)).ReturnsAsync("continuationResult");
            _continuationCommandMock.Setup(cc => cc.Continuations("continuationResult", _factoryMock.Object))
                .Returns(_noContinuationCommands);
            _continuationCommandMock.Setup(cc => cc.Name).Returns("continuationName");

            var order = 0;
            
            _textWriterMock.Setup(tw => tw.WriteLine("[+] inputName")).Callback(() => Assert.Equal(0, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] inputName")).Callback(() => Assert.Equal(1, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] inputResult")).Callback(() => Assert.Equal(2, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[+] continuationName")).Callback(() => Assert.Equal(3, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] continuationName")).Callback(() => Assert.Equal(4, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] continuationResult"))
                .Callback(() => Assert.Equal(5, order++));

            var engine = new Engine(_factoryMock.Object);
            await engine.RunAsync();

            _textWriterMock.VerifyAll();
        }

        [Fact]
        public async Task CreatesInputCommandAndExitsWhenNoContinuationsAreProvided()
        {
            Console.SetOut(_textWriterMock.Object);

            _factoryMock.Setup(f => f.Create("input")).Returns(_inputCommandMock.Object);
            _factoryMock.Setup(f => f.CancellationTokenSource).Returns(_source);

            _inputCommandMock.Setup(c => c.RunAsync(_source.Token)).ReturnsAsync("result");
            _inputCommandMock.Setup(c => c.Continuations("result", _factoryMock.Object))
                .Returns(_noContinuationCommands);
            _inputCommandMock.Setup(ic => ic.Name).Returns("name");

            var order = 0;
            
            _textWriterMock.Setup(tw => tw.WriteLine("[+] name")).Callback(() => Assert.Equal(0, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] name")).Callback(() => Assert.Equal(1, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] result")).Callback(() => Assert.Equal(2, order++));

            var engine = new Engine(_factoryMock.Object);
            await engine.RunAsync();

            _textWriterMock.VerifyAll();
        }

        [Fact]
        public async Task ManyParallelContinuationsAfterInput()
        {
            Console.SetOut(_textWriterMock.Object);

            _factoryMock.Setup(f => f.Create("input")).Returns(_inputCommandMock.Object);
            _factoryMock.Setup(f => f.CancellationTokenSource).Returns(_source);

            var continuationCommandOneMock = new Mock<Command>();
            var continuationCommandTwoMock = new Mock<Command>();
            var continuationCommandThreeMock = new Mock<Command>();

            _inputCommandMock.Setup(ic => ic.RunAsync(_source.Token)).ReturnsAsync("0");
            _inputCommandMock.Setup(ic => ic.Continuations("0", _factoryMock.Object))
                .Returns(new[]
                {
                    continuationCommandOneMock.Object, continuationCommandTwoMock.Object,
                    continuationCommandThreeMock.Object
                });
            _inputCommandMock.Setup(ic => ic.Name).Returns("name");

            continuationCommandOneMock.Setup(c => c.RunAsync(_source.Token)).ReturnsAsync("1");
            continuationCommandOneMock.Setup(c => c.Continuations("1", _factoryMock.Object))
                .Returns(_noContinuationCommands);
            continuationCommandOneMock.Setup(ic => ic.Name).Returns("n1");

            continuationCommandTwoMock.Setup(c => c.RunAsync(_source.Token)).ReturnsAsync("2");
            continuationCommandTwoMock.Setup(c => c.Continuations("2", _factoryMock.Object))
                .Returns(_noContinuationCommands);
            continuationCommandTwoMock.Setup(ic => ic.Name).Returns("n2");

            continuationCommandThreeMock.Setup(c => c.RunAsync(_source.Token)).ReturnsAsync("3");
            continuationCommandThreeMock
                .Setup(c => c.Continuations("3", _factoryMock.Object))
                .Returns(_noContinuationCommands);
            continuationCommandThreeMock.Setup(ic => ic.Name).Returns("n3");

            var order = 0;

            _textWriterMock.Setup(tw => tw.WriteLine("[+] n1")).Callback(() => Assert.Equal(0, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[+] n2")).Callback(() => Assert.Equal(1, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[+] n3")).Callback(() => Assert.Equal(2, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] n1")).Callback(() => Assert.Equal(3, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] 1")).Callback(() => Assert.Equal(4, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] n2")).Callback(() => Assert.Equal(5, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] 2")).Callback(() => Assert.Equal(6, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[-] n3")).Callback(() => Assert.Equal(7, order++));
            _textWriterMock.Setup(tw => tw.WriteLine("[=] 3")).Callback(() => Assert.Equal(8, order++));

            var engine = new Engine(_factoryMock.Object);
            await engine.RunAsync();

            _textWriterMock.VerifyAll();
        }

        [Fact]
        public void ThrowsWhenFactoryIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new Engine(null!));
        }
    }
}