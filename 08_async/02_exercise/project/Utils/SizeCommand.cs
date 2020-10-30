using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Utils
{
    public class SizeCommand :Command
    {
        private readonly IClient _client;
        public override string Name { get; }

        public SizeCommand(Uri uri, IClient client)
        {
            _client = client;
            Name = $"size '{uri}'";
            Uri = uri;
        }

        public Uri Uri { get; set; }

        public override async Task<string> RunAsync(CancellationToken cancellationToken)
        {
            var response = _client.GetAsync(Uri, CancellationToken.None);
            var result = await response;
            return $"{Uri} "+result.Length;
        }
    }
}
// var response = httpClient.GetAsync(uri, CancellationToken.None);
// Console.WriteLine("Non blocking...");
// var result = await response;
// Console.WriteLine(result.StatusCode);
// var httpClient = new HttpClient();
// var uri = new Uri("https://google.com");