using System;

namespace Utils
{
    public class ClickedEventArgs:EventArgs
    {
        public ClickedEventArgs(string label)
        {
            Label = label;
        }

        public string Label { get; }
    }
}