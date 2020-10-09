using System.Collections.Generic;

namespace Utils
{
    public class RangeFibonacci : Fibonacci
    {
        private readonly int _start;
        private readonly int _step;
        private readonly int _stop;
        public RangeFibonacci(int start=0, int step=1, int stop=1)
        {
            _start = start;
            _step = step;
            _stop = stop;
        }

        public override IEnumerable<int> Numbers()
        {
            var fibonacci = new Fibonacci();
            var numbers = fibonacci.Numbers();
            using var enumerator = numbers.GetEnumerator();

            var i = 0;
            for (; i <= _start; i++)
            {
                enumerator.MoveNext();
            }

            for (; i <= _stop; i += _step)
            {
                yield return enumerator.Current;
                for (var j = 0; j < _step; j++)
                {
                    enumerator.MoveNext();
                }
            }

            yield return enumerator.Current;
        }
    }
}