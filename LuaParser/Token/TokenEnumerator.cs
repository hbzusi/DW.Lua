using System;
using System.Collections;
using System.Collections.Generic;
using DW.Lua.Exceptions;

namespace DW.Lua.Parsers
{
    public class TokenEnumerator : ITokenEnumerator
    {
        private readonly IList<string> _tokens;
        private int _index = -1;

        public string Next { get; private set; }
        public bool HasNext => _index < _tokens.Count - 1;

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current => Current;

        public string Current { get; private set; }

        public TokenEnumerator(IList<string> tokens)
        {
            if (tokens == null) throw new ArgumentNullException(nameof(tokens));
            _tokens = tokens;
            MoveNext();
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _tokens.Count)
                return false;

            Current = _index < _tokens.Count ? _tokens[_index] : null;
            Next = _index < _tokens.Count - 1 ? _tokens[_index+1] : null;
            return _index < _tokens.Count;
        }

        public void Dispose()
        {
        }
    }
}