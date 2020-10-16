using System;
using System.IO;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class LoggingButtonTest
    {
        [Fact]
        public void LogsToConsoleWhenClicked()
        {
            var mock =new Mock<TextWriter>();
            Console.SetOut(mock.Object);

            mock.Setup(ts => ts.WriteLine("Clicked 'TEST'")).Verifiable();
            var loggingButton=new LoggingButton("TEST");
            loggingButton.Click();
            mock.Verify();
        }
    }
}