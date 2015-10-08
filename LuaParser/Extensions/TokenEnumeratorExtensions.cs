using System.Collections.Generic;
using System.Linq;
using DW.Lua.Exceptions;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Syntax;

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
                throw new UnexpectedTokenException(enumerator.Current.Value, expectedTokens);
        }

        public static void VerifyExpectedTokenAndMoveNext(this INextAwareEnumerator<Token> enumerator, params string[] expectedTokens)
        {
            enumerator.VerifyExpectedToken(expectedTokens);
            enumerator.MoveNext();
        }

        public static void VerifyIsIdentifier(this INextAwareEnumerator<Token> enumerator)
        {
            if (!LuaToken.IsIdentifier(enumerator.Current.Value))
                throw new UnexpectedTokenException(enumerator.Current.Value);
        }

        public static string GetAndMoveNext(this INextAwareEnumerator<Token> enumerator)
        {
            var token = enumerator.Current.Value;
            enumerator.MoveNext();
            return token;
        }
    }
}
