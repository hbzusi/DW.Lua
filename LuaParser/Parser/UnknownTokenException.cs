using System;

namespace LuaParser.Parser
{
    internal class UnknownTokenException : Exception
    {
        public UnknownTokenException(string message) : base(message)
        {

        }
    }
}