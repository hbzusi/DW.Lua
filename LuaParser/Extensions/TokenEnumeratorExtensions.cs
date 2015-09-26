using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaParser.Exceptions;
using LuaParser.Parsers;

namespace LuaParser.Extensions
{
    internal static class TokenEnumeratorExtensions
    {
        public static void VerifyExpectedToken(this ITokenEnumerator enumerator, params string[] expectedTokens)
        {
            if (!expectedTokens.Contains(enumerator.Current))
                throw new UnexpectedTokenException(enumerator.Current);
        }
    }
}
