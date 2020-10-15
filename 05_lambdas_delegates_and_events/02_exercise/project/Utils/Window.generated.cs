using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    public partial class Window
    {
        private LoggingButton _buttonOK;
        private LoggingButton _buttonCancel;
        
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            _buttonOK=new LoggingButton("OK");
            _buttonCancel=new LoggingButton("Cancel");

            _buttonOK.Clicked += ButtonOkClicked;
            _buttonCancel.Clicked += ButtonCancelClicked;
        }
        [ExcludeFromCodeCoverage]
        public void SimulateClicks()
        {
            _buttonCancel.Click();
            _buttonOK.Click();
        }
    }
}