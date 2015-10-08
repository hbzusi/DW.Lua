using System.Collections.Generic;
using System.Linq;
using DW.Lua.Exceptions;
using DW.Lua.Parser;
using DW.Lua.Syntax;

namespace DW.Lua.Extensions
{
    public static class TokenEnumeratorExtensions
    {
        public static void VerifyExpectedToken(this ITokenEnumerator enumerator, IEnumerable<string> expectedTokens)
        {
            VerifyExpectedToken(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedTokenAndMoveNext(this ITokenEnumerator enumerator,
            IEnumerable<string> expectedTokens)
        {
            VerifyExpectedTokenAndMoveNext(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedToken(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            if (!expectedTokens.Contains(enumerator.Current.Value))
                throw new UnexpectedTokenException(enumerator.Current.Value, expectedTokens);
        }

        public static void VerifyExpectedTokenAndMoveNext(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            enumerator.VerifyExpectedToken(expectedTokens);
            enumerator.MoveNext();
        }

        public static void VerifyIsIdentifier(this ITokenEnumerator enumerator)
        {
            if (!LuaToken.IsIdentifier(enumerator.Current.Value))
                throw new UnexpectedTokenException(enumerator.Current.Value);
        }

        public static string GetAndMoveNext(this ITokenEnumerator enumerator)
        {
            var token = enumerator.Current.Value;
            enumerator.MoveNext();
            return token;
        }
    }
}
