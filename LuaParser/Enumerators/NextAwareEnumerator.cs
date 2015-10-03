using System;
using System.Collections;
using System.Collections.Generic;

namespace DW.Lua.Enumerators
{
    public class NextAwareEnumerator<T> : INextAwareEnumerator<T>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current { get; }

        public T Next { get; }

        object IEnumerator.Current => Current;
    }

    internal interface INextAwareEnumerator<T> : IEnumerator<T>
    {
        T Next { get; }
    }
}
