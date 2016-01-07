using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class TableInitializerExpressionParserTests
    {
        [Test]
        public static void ShouldParseMultiValueInitializer()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new TableInitializerExpression(
                    new VariableExpression(new Variable("a")),
                    new StringConstantExpression("b"),
                    new ConstantExpression(Constants.Two)
                    ),
                false));
            var actual = SyntaxParser.Parse("a = {a,\"b\",2}");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void ShouldParseEmptyInitializer()
        {
            var expected = new StatementBlock(new Assignment(new Variable("a"),
                new TableInitializerExpression(),
                false));
            var actual = SyntaxParser.Parse("a = {}");
            Assert.AreEqual(expected, actual);
        }
    }
}