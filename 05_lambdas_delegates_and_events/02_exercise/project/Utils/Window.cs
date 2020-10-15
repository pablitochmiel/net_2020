using System;

namespace Utils
{
    public partial class Window
    {
        private void ButtonOkClicked(object sender, ClickedEventArgs e)
        {
            HandledButtonOkClick = true;
            Console.WriteLine($"Handled '{e.Label}'");
        }
        
        private void ButtonCancelClicked(object sender, ClickedEventArgs e)
        {
            HandledButtonCancelClick = true;
            Console.WriteLine($"Handled '{e.Label}'");
        }
        
        public bool HandledButtonOkClick { get; private set; }
        public bool HandledButtonCancelClick { get; private set; }

        public Window()
        {
            InitializeComponent();
        }
    }
}