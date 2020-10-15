using Utils;
using Xunit;

namespace Test
{
    public class WindowTest
    {
        [Fact]
        public void ClickChangeValueOfButtons()
        {
            var window = new Window();
            Assert.False(window.HandledButtonCancelClick);
            Assert.False(window.HandledButtonOkClick);
            window.SimulateClicks();
            Assert.True(window.HandledButtonCancelClick);
            Assert.True(window.HandledButtonOkClick);
        }
        
    }
}