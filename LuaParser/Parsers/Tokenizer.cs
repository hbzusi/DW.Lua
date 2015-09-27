using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DW.Lua.Parsers
{
    public static class Tokenizer
    {
        public static TokenEnumerator Parse(TextReader input)
        {
            var tokens = ReadTokens(input).ToList();

            return new TokenEnumerator(tokens);
        }

        private static IEnumerable<string> ReadTokens(TextReader reader)
        {
            while (reader.Peek() != -1)
            {
                SkipNonTokens(reader);
                yield return ReadToken(reader);
            }
        }

        private static void SkipNonTokens(TextReader reader)
        {
            do
            {
                var next = reader.Peek();
                if (next == -1)
                    break;
                var nextChar = (char)next;
                if (IsNonToken(nextChar))
                    reader.Read();
                else
                    break;
            } while (true);
        }

        private static string ReadToken(TextReader reader)
        {
            var sb = new StringBuilder();
            do
            {
                var next = reader.Peek();
                if (next == -1)
                    break;
                var nextChar = (char)next;
                if (IsNonToken(nextChar))
                    break;
                if (IsToken(nextChar) && sb.Length > 0)
                    break;
                sb.Append(nextChar);
                reader.Read();
                if (IsToken(nextChar) && sb.Length == 1) // now after adding the new char the length is 1 
                    break;
            } while (true);
            return sb.ToString();
        }

        private static string TokenCharsString = "{}()[]+-/*=\n,:";
        private static string NonTokenCharsString = "\t\r ";

        private static readonly char[] TokenChars = TokenCharsString.ToCharArray();
        private static readonly char[] NonTokenChars = NonTokenCharsString.ToCharArray();

        private static bool IsToken(char chr)
        {
            return TokenChars.Contains(chr);
        }

        private static bool IsNonToken(char chr)
        {
            return NonTokenChars.Contains(chr);
        }
    }
}
