using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Test
{
    public class CommandTest
    {
        [ExcludeFromCodeCoverage]
        private class DummyCommand : Command
        {
            public override Task<string> RunAsync(CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void HasEmptyName()
        {
            var command = new DummyCommand();
            Assert.Empty(command.Name);
        }

        [Fact]
        public void ThereAreNoDefaultContinuations()
        {
            var command = new DummyCommand();
            Assert.Empty(command.Continuations(null!, null!));
        }
    }
}