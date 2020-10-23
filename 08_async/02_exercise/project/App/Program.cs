using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static async Task Main()
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            var commandFactory = new CommandFactory(cancellationTokenSource);
            var engine = new Engine(commandFactory);
            await engine.RunAsync();
            
            cancellationTokenSource.Dispose();
        }
    }
}