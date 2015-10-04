using System.Collections.Generic;
using System.Linq;
using DW.Lua.Exceptions;
using DW.Lua.Parsers;

namespace DW.Lua.Extensions
{
    internal static class TokenEnumeratorExtensions
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
            if (!expectedTokens.Contains(enumerator.Current))
                throw new UnexpectedTokenException(enumerator.Current, expectedTokens);
        }

        public static void VerifyExpectedTokenAndMoveNext(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            enumerator.VerifyExpectedToken(expectedTokens);
            enumerator.MoveNext();
        }
    }
}
