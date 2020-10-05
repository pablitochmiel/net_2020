using System;
using System.IO;
using Modeling;
using Moq;
using Xunit;

namespace Test
{
    public class FileSourceTest
    {
        [Fact]
        public void ReadsSourceWithNoData()
        {
            var mockTextReader = new Mock<TextReader>(MockBehavior.Strict);
            mockTextReader.SetupSequence(tr => tr.ReadLine()).Returns((string?) null);
            
            var fileSource = new FileSource(mockTextReader.Object);
            Assert.Equal(0, fileSource.Sample(1));
        }

        [Fact]
        public void ReadsSourceWithOneValidLine()
        {
            var mockTextReader = new Mock<TextReader>(MockBehavior.Strict);
            mockTextReader.SetupSequence(tr => tr.ReadLine()).Returns("1 10").Returns((string?) null);
            
            var fileSource = new FileSource(mockTextReader.Object);
            Assert.Equal(10, fileSource.Sample(0.9));
            Assert.Equal(10, fileSource.Sample(1));
            Assert.Equal(10, fileSource.Sample(1.1));
        }

        [Fact]
        public void ReadsSourceWithOneValidLineFloatingPoint()
        {
            var mockTextReader = new Mock<TextReader>(MockBehavior.Strict);
            mockTextReader.SetupSequence(tr => tr.ReadLine()).Returns("1.1 10.2").Returns((string?) null);
            
            var fileSource = new FileSource(mockTextReader.Object);
            Assert.Equal(10.2, fileSource.Sample(1.0), 1);
            Assert.Equal(10.2, fileSource.Sample(1.1), 1);
            Assert.Equal(10.2, fileSource.Sample(1.2), 1);
        }

        [Fact]
        public void ReadsSourceWithTwoValidLines()
        {
            var mockTextReader = new Mock<TextReader>(MockBehavior.Strict);
            mockTextReader.SetupSequence(tr => tr.ReadLine()).Returns("1 10").Returns("2 20").Returns((string?) null);
            
            var fileSource = new FileSource(mockTextReader.Object);
            Assert.Equal(10, fileSource.Sample(0));
            Assert.Equal(10, fileSource.Sample(1));
            Assert.Equal(15, fileSource.Sample(1.5));
            Assert.Equal(20, fileSource.Sample(2));
            Assert.Equal(20, fileSource.Sample(3));
        }

        [Fact]
        public void ThrowsWhenLineHasInvalidData()
        {
            var mockTextReader = new Mock<TextReader>(MockBehavior.Strict);
            mockTextReader.Setup(tr => tr.ReadLine()).Returns("10");
            
            Assert.Throws<InvalidFileException>(() => new FileSource(mockTextReader.Object));
        }

        [Fact]
        public void ThrowsWhenTextReaderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new FileSource(null));
        }
    }
}