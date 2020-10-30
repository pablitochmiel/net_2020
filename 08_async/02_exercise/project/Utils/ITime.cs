using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public interface ITime
    {
        Task Delay(int millisecondsDelay, CancellationToken cancellationToken);
    }
}