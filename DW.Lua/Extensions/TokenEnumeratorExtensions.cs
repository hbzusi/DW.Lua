using System.Collections.Generic;
using System.Linq;
using DW.Lua.Exceptions;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Tokenizer;

namespace DW.Lua.Extensions
{
    public static class TokenEnumeratorExtensions
    {
        public static void VerifyExpectedToken(this INextAwareEnumerator<Token> enumerator, IEnumerable<string> expectedTokens)
        {
            VerifyExpectedToken(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedTokenAndMoveNext(this INextAwareEnumerator<Token> enumerator,
            IEnumerable<string> expectedTokens)
        {
            VerifyExpectedTokenAndMoveNext(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedToken(this INextAwareEnumerator<Token> enumerator, params string[] expectedTokens)
        {
            if (!expectedTokens.Contains(enumerator.Current.Value))
                throw new UnexpectedTokenException(enumerator.Current, expectedTokens);
        }

        public static void VerifyExpectedTokenAndMoveNext(this INextAwareEnumerator<Token> enumerator, params string[] expectedTokens)
        {
            enumerator.VerifyExpectedToken(expectedTokens);
            enumerator.MoveNext();
        }

        public static void VerifyIsIdentifier(this INextAwareEnumerator<Token> enumerator)
        {
            if (!LuaToken.IsIdentifier(enumerator.Current.Value))
                throw new UnexpectedTokenException(enumerator.Current);
        }

        public static Token GetAndMoveNext(this INextAwareEnumerator<Token> enumerator)
        {
            var token = enumerator.Current;
            enumerator.MoveNext();
            return token;
        }
    }
}
