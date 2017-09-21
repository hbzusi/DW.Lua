using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class StringConstantExpressionParserTests
    {
        [Test]
        public static void ShouldParseStringAssignment()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new StringConstantExpression("TEST"), false));
            var actual = SyntaxParser.Parse("a = \"TEST\"");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void ShouldParseMultilineStringAssignment()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new StringConstantExpression("TEST1\nTEST2"), false));
            var actual = SyntaxParser.Parse("a = [[TEST1\nTEST2]]");
            Assert.AreEqual(expected, actual);
        }
    }
}