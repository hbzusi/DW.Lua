using System;
using System.Collections;
using System.Collections.Generic;

namespace LuaParser.Parser
{
    public class TokenEnumerator : IEnumerable<string>
    {
        private readonly IList<string> _tokens;
        private int index = -1;

        public string Previous { get; private set; }
        public string Next { get; private set; }
        public string Current { get; private set; }

        public TokenEnumerator(IList<string> tokens)
        {
            if (tokens == null) throw new ArgumentNullException("tokens");
            _tokens = tokens;
            Advance();
        }

        public void Advance()
        {
            index++;
            if (index > 0)
                Previous = _tokens[index - 1];
            Current = _tokens[index];
            if (index < _tokens.Count - 1)
                Next = _tokens[index];
            else
                Next = null;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}