using System.Collections.Generic;
using DW.Lua.Misc;

namespace DW.Lua.Lexer
{
    public class TokenizerCharEnumerator : NextAwareEnumerator<char>, ITokenizerCharEnumerator
    {
        public TokenizerCharEnumerator(IEnumerator<char> sourceEnumerator) : base(sourceEnumerator)
        {
        }

        public int TextPosition { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }

        private void AdvanceLine()
        {
            Column = 0;
            Line++;
        }

        public override bool MoveNext()
        {
            var result = base.MoveNext();
            if (result)
            {
                if (Current == '\n')
                    AdvanceLine();
                TextPosition++;
            }
            return result;
        }
    }
}