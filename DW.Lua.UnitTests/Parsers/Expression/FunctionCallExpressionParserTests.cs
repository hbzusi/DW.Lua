using System.Linq;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class FunctionCallExpressionParserTests
    {
        [Test]
        public static void ShouldParseNoArgumentsCall()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new FunctionCallExpression("b", Enumerable.Empty<LuaExpression>()), false));
            var actual = SyntaxParser.Parse("a = b()");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void ShouldParseMultipleArgumentsCall()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new FunctionCallExpression("b",
                    new VariableExpression(new Variable("c")),
                    new VariableExpression(new Variable("d")),
                    new VariableExpression(new Variable("e"))
                    ), false));
            var actual = SyntaxParser.Parse("a = b(c,d,e)");
            Assert.AreEqual(expected, actual);
        }
    }
}