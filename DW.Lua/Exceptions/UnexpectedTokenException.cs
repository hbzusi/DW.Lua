using System;
using DW.Lua.Lexer;

namespace DW.Lua.Exceptions
{
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(Token token)
            : base($"{token.Position}: '{token.Value}' was unexpected at this time")
        {
        }

        public UnexpectedTokenException(Token token, params string[] expectedTokens)
            : base(
                $"{token.Position}: '{token.Value}' was unexpected at this time, expected '{string.Join("' or '", expectedTokens)}'"
                )
        {
        }
    }
}