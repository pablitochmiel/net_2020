using System;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public interface IClient
    {
        public Task<string> GetAsync(Uri uri, CancellationToken token);
    }
}