using System;
using System.Collections;
using System.Collections.Generic;
using DW.Lua.Parser;

namespace DW.Lua.Language
{
    public class TokenEnumerator : ITokenEnumerator
    {
        private readonly IList<Token> _tokens;
        private int _index = -1;

        public Token Next { get; private set; }
        public bool HasNext => _index < _tokens.Count - 1;

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current => Current;

        public Token Current { get; private set; }

        public TokenEnumerator(IList<Token> tokens)
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