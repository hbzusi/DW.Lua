using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class FunctionCallExpressionParserTests
    {
        [Test]
        public static void ShouldParseNoArgumentsCall()
        {
            SyntaxParser.Parse("a = b()");
            Assert.Inconclusive("Need to check return value");
        }

        [Test]
        public static void ShouldParseMultipleArgumentsCall()
        {
            SyntaxParser.Parse("a = b(c,d,e)");
            Assert.Inconclusive("Need to check return value");
        }
    }
}
