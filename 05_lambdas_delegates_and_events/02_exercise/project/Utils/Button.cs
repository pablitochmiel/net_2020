using System;

namespace Utils
{
    public class Button
    {
        public Button(string label)
        {
            Label = label;
        }

        protected string Label{ get; }
        public event EventHandler<ClickedEventArgs>? Clicked;

        public void Click()
        {
            OnClicked();
        }

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this,new ClickedEventArgs(Label));
        }
    }
}