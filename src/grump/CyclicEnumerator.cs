using System.Collections;
using System.Collections.Generic;
using mxwlf.net.Validation;

namespace Grump
{
    public class CyclicEnumerator<T> : IEnumerator<T>, IEnumerable<T>
    {
        private T[] _elements;
        private int _iterator = 0;
        private int _currentIndex = 0;
        private readonly int _length = 0;

        public CyclicEnumerator(T[] elements)
        {
            elements.ThrowIfNull();

            _elements = elements;
            _length = _elements.Length;
            _currentIndex = 0;
        }

        public bool MoveNext()
        {
            _currentIndex = ++_iterator % _length;
            return true;
        }

        public void Reset()
        {
            _iterator = 0;
        }

        public T Current => _elements[_currentIndex];

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            _elements = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}