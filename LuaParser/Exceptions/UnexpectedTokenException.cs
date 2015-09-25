using System;

namespace LuaParser.Exceptions
{
    internal class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(string token) 
            :base(string.Format("Token '{0}' was unexpected at this time",token))
        { }

        public UnexpectedTokenException(string token, params string[] expectedTokens)
            : base(string.Format("Token '{0}' was unexpected at this time, expected '{1}'", token, string.Join("' or '", expectedTokens)))
        { }
    }
}