using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class DelayedPrintCommand:Command
    {
        public override async Task<string> RunAsync(CancellationToken cancellationToken)
        {
            await _time.Delay(Delay, cancellationToken);
            return Message;
        }

        public int Delay { get; }
        public string Message { get; }
        private readonly ITime _time;

        public DelayedPrintCommand(string message, in int delay, ITime time)
        {
            Message = message;
            _time = time;
            Name = $"delayed print '{message}' in {delay} ms";
            Delay = delay;
        }

        public override string Name { get; }
    }
}