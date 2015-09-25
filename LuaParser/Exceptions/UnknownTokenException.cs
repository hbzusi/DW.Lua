using System;

namespace LuaParser.Exceptions
{
    internal class UnknownTokenException : Exception
    {
        public UnknownTokenException(string message) : base(message)
        {

        }
    }
}