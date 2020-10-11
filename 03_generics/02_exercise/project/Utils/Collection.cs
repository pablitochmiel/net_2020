using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    // TODO: Generic Collection<T> class...
    // TODO: Elements stored in plain array (T[] _elements)...
    public class Collection<T>:IEnumerable<T>
    {
        public Collection(int capacity=1, int factor=2)
        {
            Capacity = capacity;
            Count = 0;
            Factor = factor;
            _elements=new T[capacity];
        }

        public int Factor { get; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private T[] _elements;

        public void Add(T p0)
        {
            if (Count < Capacity)
            {
                _elements[Count] = p0;
                Count++;
            }
            else
            {
                var temp = _elements;
                Capacity *= Factor;
                _elements = new T[Capacity];
                temp.CopyTo(_elements, 0);
                _elements[Count] = p0;
                Count++;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public ElementsEnum<T> GetEnumerator()
        {
            return new ElementsEnum<T>(_elements);
        }

        public T this[int i] => _elements[i];
    }

    public sealed class ElementsEnum<T>:IEnumerator<T>
    {
        private readonly T[] _elements;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        private int _position = -1;

        public ElementsEnum(T[] list)
        {
            _elements = list;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _elements.Length;
        }

        public void Reset()
        {
        }

        object? IEnumerator.Current => Current;

        public T Current => _elements[_position];

        public void Dispose()
        {
        }
    }
}