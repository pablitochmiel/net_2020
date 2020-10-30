using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class Client : IClient
    {
        private readonly HttpClient _httpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(Uri uri, CancellationToken token)
        {
            await Task.Delay(0, token);
            return "";
            // var response = _httpClient.GetAsync(uri, CancellationToken.None);
            // var result = await response;
            // return $"{uri} " + result.ToString().Length;
        }
    }
}
