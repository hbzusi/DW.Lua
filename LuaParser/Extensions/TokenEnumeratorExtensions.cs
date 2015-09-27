using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LuaParser.Exceptions;
using LuaParser.Parsers;

namespace LuaParser.Extensions
{
    internal static class TokenEnumeratorExtensions
    {
        public static void VerifyExpectedToken(this ITokenEnumerator enumerator, IEnumerable<string> expectedTokens)
        {
            VerifyExpectedToken(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedTokenAndAdvance(this ITokenEnumerator enumerator,
            IEnumerable<string> expectedTokens)
        {
            VerifyExpectedTokenAndAdvance(enumerator, expectedTokens.ToArray());
        }

        public static void VerifyExpectedToken(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            if (!expectedTokens.Contains(enumerator.Current))
                throw new UnexpectedTokenException(enumerator.Current, expectedTokens);
        }

        public static void VerifyExpectedTokenAndAdvance(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            enumerator.VerifyExpectedToken(expectedTokens);
            enumerator.Advance();
        }
    }
}
