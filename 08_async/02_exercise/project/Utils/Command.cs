using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public abstract class Command
    {
        protected Command()
        {
            Name = "";
        }

        public virtual string Name { get; }
        public abstract Task<string> RunAsync(CancellationToken cancellationToken);

        public virtual IEnumerable<Command> Continuations(string result, ICommandFactory commandFactory)
        {
            return new Collection<Command>();
        }
    }
}