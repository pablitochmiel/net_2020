using Modeling;
using Xunit;

namespace Test
{
    public class InvalidFileExceptionTest
    {
        [Fact]
        public void CanCreateWithMessage()
        {
            const string message = "Sth.";
            var exception = new InvalidFileException(message);
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CanCreateWithMessageAndNestedException()
        {
            const string message = "Sth.";
            var innerException = new InvalidFileException();

            var exception = new InvalidFileException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        [Fact]
        public void CanCreateWithoutParameters()
        {
            Assert.NotNull(new InvalidFileException());
        }
    }
}