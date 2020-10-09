using System;
using System.Collections.Generic;

namespace Utils
{
    public class Fibonacci
    {
        private int _a;
        private int _b;
        private int _count;

        public Fibonacci()
        {
            _b = 1;
            _a = 0;
            _count = 0;
        }

        public virtual IEnumerable<int> Numbers()
        {
            while (_count<44)
            {
                _count++;
                yield return _a;
                _count++;
                yield return _b;
                _a += _b;
                _b += _a;
            }
            throw new IndexOutOfRangeException();
        }
    }
}