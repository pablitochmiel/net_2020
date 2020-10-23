using System;
using System.Threading;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class SizeCommandTest
    {
        [Fact]
        public async void CanGetSizeOfPage()
        {
            var uri = new Uri("http://demo.com");
            var mock = new Mock<IClient>();

            var sizeCommand = new SizeCommand(uri, mock.Object);

            mock.Setup(c => c.GetAsync(uri, CancellationToken.None)).ReturnsAsync("12345");

            var result = await sizeCommand.RunAsync(CancellationToken.None);

            Assert.Equal($"{uri} 5", result);
        }

        [Fact]
        public void HasName()
        {
            var uri = new Uri("http://demo.com");
            var mock = new Mock<IClient>();

            var sizeCommand = new SizeCommand(uri, mock.Object);

            Assert.Equal(uri, sizeCommand.Uri);
            Assert.Equal($"size '{uri}'", sizeCommand.Name);
        }
    }
}