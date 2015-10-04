using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers
{
    public class Tokenizer
    {
        private static readonly HashSet<char> SingleCharTokenChars =
            new HashSet<char>(LuaToken.SingleCharTokensString.ToCharArray());

        private static readonly HashSet<char> NonTokenChars =
            new HashSet<char>(LuaToken.NonTokenCharsString.ToCharArray());

        private Tokenizer(TextReader reader)
        {
            Reader = reader;
        }

        private TextReader Reader { get; }

        private bool HasNextChar => Reader.Peek() != -1;

        public static TokenEnumerator Parse(TextReader reader)
        {
            var tokenizer = new Tokenizer(reader);
            var tokens = tokenizer.ReadTokens().ToList();
            return new TokenEnumerator(tokens);
        }

        private IEnumerable<string> ReadTokens()
        {
            while (HasNextChar)
            {
                SkipNonTokens();
                yield return ReadToken();
            }
        }

        private char GetNextChar()
        {
            if (!HasNextChar) throw new InvalidOperationException("Cannot read next character: stream ended");
            return (char) Reader.Peek();
        }

        private void SkipNonTokens()
        {
            do
            {
                var next = Reader.Peek();
                if (next == -1)
                    break;
                var nextChar = (char) next;
                if (IsNonToken(nextChar))
                    Reader.Read();
                else
                    break;
            } while (true);
        }

        private string ReadToken()
        {
            var sb = new StringBuilder();
            while (HasNextChar)
            {
                var nextChar = GetNextChar();
                if (IsNonToken(nextChar))
                    break;
                if (IsSingleCharToken(nextChar) && sb.Length > 0)
                    break;
                sb.Append(nextChar);
                Reader.Read();
                if (IsSingleCharToken(nextChar) && sb.Length == 1) // now after adding the new char the length is 1 
                    break;
            }
            return sb.ToString();
        }

        private static bool IsSingleCharToken(char chr)
        {
            return SingleCharTokenChars.Contains(chr);
        }

        private static bool IsNonToken(char chr)
        {
            return NonTokenChars.Contains(chr);
        }
    }
}