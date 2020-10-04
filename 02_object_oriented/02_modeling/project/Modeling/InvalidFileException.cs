using System;

namespace Modeling
{
    public class InvalidFileException: SystemException
    {
        public InvalidFileException(string message) : base(message)
        {
        }

        public InvalidFileException()
        {
        }

        public InvalidFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}