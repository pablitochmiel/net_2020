using Utils;
using Xunit;

namespace Test
{
    public class ButtonTest
    {
        [Fact]
        public void ClickCallTriggersClickedEvent()
        {
            var button=new Button("OK");

            var raisedEvent = Assert.Raises<ClickedEventArgs>(handler => button.Clicked += handler,
                handler => button.Clicked -= handler, () => button.Click());
            Assert.Equal("OK", raisedEvent.Arguments.Label);
        }
    }
}