namespace Utils
{
    public class Calculator
    {
        private readonly double _a;
        private readonly double _b;
        public Calculator(double d, double d1)
        {
            _a = d;
            _b = d1;
        }

        public double Add()
        {
            return _a + _b;
        }

        public double Sub()
        {
            return _a - _b;
        }

        public double Mul()
        {
            return _a * _b;
        }

        public double Div()
        {
            return _a / _b;
        }
    }
}