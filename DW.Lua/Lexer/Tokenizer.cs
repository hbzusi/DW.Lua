using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Language;
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
            var position = _reader.Position;
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
                    return new Token(ReadComment(), position, TokenType.Comment);

                if (_reader.Current == '[' && _reader.Next == '[')
                    return new Token(ReadMultiLineStringConstant(), position, TokenType.StringConstant);

                if (_reader.Current == '"')
                    return new Token(ReadSingleLineStringConstant(), position, TokenType.StringConstant);

                if (IsSingleCharToken(_reader.Current))
                    break;

                if (_reader.HasNext && (IsNonToken(_reader.Next) || IsSingleCharToken(_reader.Next)))
                    break;

                _reader.MoveNext();
            }
            var tokenValue = builder.ToString();
            bool dummy;
            var tokenType = TokenType.Identifier;
            if (Keywords.All.Contains(tokenValue))
                tokenType = TokenType.Keyword;
            else if (bool.TryParse(tokenValue, out dummy))
                tokenType = TokenType.BooleanConstant;

            return new Token(tokenValue, position, tokenType);
        }

        private string ReadSingleLineStringConstant()
        {
            Verify(_reader.Current == '"');
            var sb = new StringBuilder();
            while (_reader.MoveNext() && _reader.Current != '"')
                sb.Append(_reader.Current);
            return sb.ToString();
        }

        private string ReadMultiLineStringConstant()
        {
            Verify(_reader.Current == '[');
            _reader.MoveNext();
            Verify(_reader.Current == '[');
            _reader.MoveNext();
            var valueBuilder = new StringBuilder();
            while (!(_reader.Current == ']' && _reader.HasNext && _reader.Next == ']'))
            {
                valueBuilder.Append(_reader.Current);
                if (!_reader.MoveNext())
                    break;
            }
            Verify(_reader.Current == ']');
            Verify(_reader.MoveNext());
            Verify(_reader.Current == ']');
            return valueBuilder.ToString();
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

        private string ReadComment()
        {
            Verify(_reader.Current == '-');
            Verify(_reader.MoveNext());
            Verify(_reader.Current == '-');
            Verify(_reader.MoveNext());
            var multiline = _reader.Current == '[' && _reader.HasNext && _reader.Next == '[';
            if (multiline)
            {
                _reader.MoveNext();
                _reader.MoveNext();
            }

            var builder = new StringBuilder();
            if (multiline)
            {
                do
                    builder.Append(_reader.Current); while (_reader.MoveNext() &&
                                                            !(_reader.Current == ']' && _reader.HasNext &&
                                                              _reader.Next == ']'));
                _reader.MoveNext();
            }
            else
                do
                    builder.Append(_reader.Current); while (_reader.MoveNext() && _reader.Current != '\n');
            return builder.ToString();
        }

        // ReSharper disable once UnusedParameter.Local
        // TODO: make a method similar to VerifyExpectedToken
        private void Verify(bool assumption)
        {
            if (!assumption)
                throw new Exception("Assumption failed");
        }
    }
}