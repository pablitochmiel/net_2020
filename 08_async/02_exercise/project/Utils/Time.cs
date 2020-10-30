using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class Time:ITime
    {
        public Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
        {
            return Task.Delay(millisecondsDelay, cancellationToken);
        }
    }
}