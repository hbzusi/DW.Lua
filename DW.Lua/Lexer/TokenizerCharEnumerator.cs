using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Lexer
{
    public class TokenizerCharEnumerator : NextAwareEnumerator<char>, ITokenizerCharEnumerator
    {
        public TokenizerCharEnumerator(IEnumerator<char> sourceEnumerator) : base(sourceEnumerator)
        {
        }

        private int _textPosition;
        private int _line = 1;
        private int _column = 1;

        private void AdvanceLine()
        {
            _column = 1;
            _line++;
        }

        public override bool MoveNext()
        {
            var result = base.MoveNext();
            if (result)
            {
                if (Current == '\n')
                    AdvanceLine();
                _textPosition++;
                _column++;
            }
            return result;
        }

        public TokenPosition Position => new TokenPosition(_line,_textPosition,_column);
    }
}