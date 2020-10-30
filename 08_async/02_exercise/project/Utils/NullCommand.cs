using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class NullCommand : Command
    {
        public NullCommand()
        {
            Name = "null";
        }

        public override string Name { get; }
        public override async Task<string> RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(0,cancellationToken);
            return Name;
        }
    }
}