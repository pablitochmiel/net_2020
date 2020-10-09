using System.Collections.Generic;

namespace Utils
{
    public class Generator
    {
        private readonly int _times;

        public Generator(int times)
        {
            _times = times;
        }

        public IEnumerable<string> Words()
        {
            for (var i = 0; i < _times; i++)
            {
                yield return "Hello";
                yield return "World";
            }
        }
    }
}