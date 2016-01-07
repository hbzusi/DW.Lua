using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class StringConstantExpressionParserTests
    {
        [Test]
        public static void ShouldParseStringAssignment()
        {
            SyntaxParser.Parse("a = \"TEST\"");
        }

        [Test]
        public static void ShouldParseMultilineStringAssignment()
        {
            SyntaxParser.Parse("a = [[TEST1\nTEST2]]");
        }
    }
}
