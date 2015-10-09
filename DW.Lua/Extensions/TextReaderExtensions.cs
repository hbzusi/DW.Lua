using System;
using System.Collections.Generic;
using System.IO;

namespace DW.Lua.Extensions
{
    public static class TextReaderExtensions
    {
        public static IEnumerable<char> AsEnumerable(this TextReader reader)
        {
            while (reader.HasNextChar())
                yield return reader.GetNextChar();
        }

        private static bool HasNextChar(this TextReader reader) => reader.Peek() != -1;

        private static char GetNextChar(this TextReader reader)
        {
            if (!reader.HasNextChar())
                throw new InvalidOperationException("Cannot read next character: stream ended");
            var chr = (char) reader.Peek();
            reader.Read();
            return chr;
        }
    }
}