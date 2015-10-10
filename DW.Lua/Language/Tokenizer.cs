using System.Collections.Generic;
using System.IO;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Language
{
    public class Tokenizer
    {
        private static readonly HashSet<char> SingleCharTokenChars =
            new HashSet<char>(LuaToken.SingleCharTokensString.ToCharArray());

        private static readonly HashSet<char> NonTokenChars =
            new HashSet<char>(LuaToken.NonTokenCharsString.ToCharArray());

        private static readonly HashSet<string> Bigrams =
            new HashSet<string>(LuaToken.TokenBigrams);

        private readonly INextAwareEnumerator<char> _reader;
        private int _position;
        private int _line = 1;

        private Tokenizer(TextReader reader)
        {
            _reader = reader.AsEnumerable().GetNextAwareEnumerator();
        }

        public static INextAwareEnumerator<Token> Parse(TextReader reader)
        {
            var tokenizer = new Tokenizer(reader);
            var tokens = tokenizer.ReadTokens();
            return tokens.GetNextAwareEnumerator();
        }

        /// <summary>
        /// Advances the character enumerator, keeping track of 
        /// number of characters and lines encountered
        /// </summary>
        /// <returns></returns>
        private bool ReaderMoveNext()
        {
            _position++;
            if (_reader.Current == '\n')
                _line++;
            return _reader.MoveNext();
        }

        private IEnumerable<Token> ReadTokens()
        {
            while (ReaderMoveNext())
            {
                SkipNonTokens();
                yield return ReadToken();
            }
        }

        private void SkipNonTokens()
        {
            // Spin reader until either all non-tokens are skipped or enumerator is finished
            while (IsNonToken(_reader.Current) && ReaderMoveNext())
            {
            }
        }

        private Token ReadToken()
        {
            var builder = new StringBuilder();
            var startPosition = _position;
            while (true)
            {
                builder.Append(_reader.Current);

                if (!_reader.HasNext)
                    break;

                if (IsBigram(_reader.Current, _reader.Next))
                {
                    ReaderMoveNext();
                    builder.Append(_reader.Current);
                    break;
                }

                if (_reader.Current == '-' && _reader.Next == '-')
                {
                    while (ReaderMoveNext() && _reader.Current != '\n')
                        builder.Append(_reader.Current);
                    ReaderMoveNext();
                    var pos = new TokenPosition(_line, startPosition, _position);
                    return new Token(builder.ToString(), pos, TokenType.Comment);
                }

                if (IsSingleCharToken(_reader.Current))
                    break;

                if (_reader.HasNext && (IsNonToken(_reader.Next) || IsSingleCharToken(_reader.Next)))
                    break;

                ReaderMoveNext();
            }
            var tokenPosition = new TokenPosition(_line, startPosition, _position);
            return new Token(builder.ToString(), tokenPosition, TokenType.Keyword);
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