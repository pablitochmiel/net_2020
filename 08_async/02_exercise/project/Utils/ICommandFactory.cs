using System.Threading;

namespace Utils
{
    public interface ICommandFactory
    {
        CancellationTokenSource CancellationTokenSource { get; }
        Command Create(params string[] arguments);
    }
}