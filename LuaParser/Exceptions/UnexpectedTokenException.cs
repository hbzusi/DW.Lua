using System;

namespace DW.Lua.Exceptions
{
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(string token) 
            :base($"Token '{token}' was unexpected at this time")
        { }

        public UnexpectedTokenException(string token, params string[] expectedTokens)
            : base($"Token '{token}' was unexpected at this time, expected '{string.Join("' or '", expectedTokens)}'")
        { }
    }
}