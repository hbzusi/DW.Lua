using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DW.Lua.Parsers
{
    public class Tokenizer
    {
        private TextReader Reader { get; }

        public static TokenEnumerator Parse(TextReader reader)
        {
            var tokenizer = new Tokenizer(reader);
            var tokens = tokenizer.ReadTokens().ToList();
            return new TokenEnumerator(tokens);
        }

        private IEnumerable<string> ReadTokens()
        {
            while (Reader.Peek() != -1)
            {
                SkipNonTokens();
                yield return ReadToken();
            }
        }

        private void SkipNonTokens()
        {
            do
            {
                var next = Reader.Peek();
                if (next == -1)
                    break;
                var nextChar = (char)next;
                if (IsNonToken(nextChar))
                    Reader.Read();
                else
                    break;
            } while (true);
        }

        private string ReadToken()
        {
            var sb = new StringBuilder();
            int next;
            while ((next = Reader.Peek()) != -1)
            {
                var nextChar = (char)next;
                if (IsNonToken(nextChar))
                    break;
                if (IsToken(nextChar) && sb.Length > 0)
                    break;
                sb.Append(nextChar);
                Reader.Read();
                if (IsToken(nextChar) && sb.Length == 1) // now after adding the new char the length is 1 
                    break;
            }
            return sb.ToString();
        }

        private const string TokenCharsString = "{}()[]+-/*=\n,:";
        private static readonly string NonTokenCharsString = "\t\r ";

        private static readonly char[] TokenChars = TokenCharsString.ToCharArray();
        private static readonly char[] NonTokenChars = NonTokenCharsString.ToCharArray();

        private Tokenizer(TextReader reader)
        {
            Reader = reader;
        }

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
