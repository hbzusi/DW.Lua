using System.Collections.Generic;
using System.IO;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Lexer
{
    public class Tokenizer
    {
        private static readonly HashSet<char> SingleCharTokenChars =
            new HashSet<char>(LuaToken.SingleCharTokensString.ToCharArray());

        private static readonly HashSet<char> NonTokenChars =
            new HashSet<char>(LuaToken.NonTokenCharsString.ToCharArray());

        private static readonly HashSet<string> Bigrams =
            new HashSet<string>(LuaToken.TokenBigrams);

        private readonly ITokenizerCharEnumerator _reader;

        private Tokenizer(TextReader reader)
        {
            _reader = new TokenizerCharEnumerator(reader.AsEnumerable().GetEnumerator());
        }

        public static INextAwareEnumerator<Token> Parse(TextReader reader)
        {
            var tokenizer = new Tokenizer(reader);
            var tokens = tokenizer.ReadTokens();
            return tokens.GetNextAwareEnumerator();
        }

        private IEnumerable<Token> ReadTokens()
        {
            while (_reader.MoveNext())
            {
                SkipNonTokens();
                yield return ReadToken();
            }
        }

        private void SkipNonTokens()
        {
            // Spin reader until either all non-tokens are skipped or enumerator is finished
            while (IsNonToken(_reader.Current) && _reader.MoveNext())
            {
            }
        }

        private Token ReadToken()
        {
            var builder = new StringBuilder();
            while (true)
            {
                builder.Append(_reader.Current);

                if (!_reader.HasNext)
                    break;

                if (IsBigram(_reader.Current, _reader.Next))
                {
                    _reader.MoveNext();
                    builder.Append(_reader.Current);
                    break;
                }

                if (_reader.Current == '-' && _reader.Next == '-')
                {
                    while (_reader.MoveNext() && _reader.Current != '\n')
                        builder.Append(_reader.Current);
                    _reader.MoveNext();
                    return new Token(builder.ToString(), _reader.Position, TokenType.Comment);
                }

                if (IsSingleCharToken(_reader.Current))
                    break;

                if (_reader.HasNext && (IsNonToken(_reader.Next) || IsSingleCharToken(_reader.Next)))
                    break;

                _reader.MoveNext();
            }
            return new Token(builder.ToString(), _reader.Position, TokenType.Keyword);
        }

        private static bool IsBigram(char char1, char char2)
        {
            var candidateBigram = new string(new[] {char1, char2});
            return Bigrams.Contains(candidateBigram);
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