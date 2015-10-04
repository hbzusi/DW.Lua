using System;
using System.Collections;
using System.Collections.Generic;

namespace DW.Lua.Enumerators
{
    public class NextAwareEnumerator<T> : INextAwareEnumerator<T>
    {
        private readonly IEnumerator<T> _sourceEnumerator;
        private T _next;

        public NextAwareEnumerator(IEnumerator<T> sourceEnumerator)
        {
            _sourceEnumerator = sourceEnumerator;
            HasNext = _sourceEnumerator.MoveNext();
            if (HasNext)
                Next = _sourceEnumerator.Current;
        }

        public void Dispose()
        {
            _sourceEnumerator.Dispose();
        }

        public bool MoveNext()
        {
            Current = _next;
            var canAdvancePrev = HasNext;
            if (HasNext)
            {
                HasNext = _sourceEnumerator.MoveNext();
                if (HasNext)
                    Next = _sourceEnumerator.Current;
            }
            return canAdvancePrev;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public T Current { get; private set; }

        public T Next
        {
            get
            {
                if (!HasNext) throw new InvalidOperationException("Sequence does not have next element");
                return _next;
            }
            private set { _next = value; }
        }

        public bool HasNext { get; private set; }

        object IEnumerator.Current => Current;
    }

    public interface INextAwareEnumerator<out T> : IEnumerator<T>
    {
        T Next { get; }
        bool HasNext { get; }
    }
}
