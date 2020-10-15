using System;

namespace Utils
{
    public class LoggingButton:Button
    {
        protected override void OnClicked()
        {
            base.OnClicked();
            Console.WriteLine($"Clicked '{Label}'");
            
        }
        public LoggingButton(string label) : base(label)
        {
        }
    }
}