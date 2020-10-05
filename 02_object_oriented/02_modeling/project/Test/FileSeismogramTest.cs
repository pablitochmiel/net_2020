using System.IO;
using Modeling;
using Moq;
using Xunit;

namespace Test
{
    public class FileSeismogramTest
    {
        [Fact]
        public void Close()
        {
            var mockTextWriter = new Mock<TextWriter>(MockBehavior.Strict);
            var fileSeismogram = new FileSeismogram(mockTextWriter.Object);

            mockTextWriter.Setup(tw => tw.Close()).Verifiable();

            fileSeismogram.Close();

            mockTextWriter.Verify();
        }

        [Fact]
        public void StoreWritesToFile()
        {
            var mockTextWriter = new Mock<TextWriter>(MockBehavior.Strict);
            var fileSeismogram = new FileSeismogram(mockTextWriter.Object);

            const double time = 10.1;
            const double value = 12.2;

            mockTextWriter.Setup(tw => tw.WriteLine("10.1 12.2")).Verifiable();
            fileSeismogram.Store(time, value);

            mockTextWriter.Verify();
        }
    }
}