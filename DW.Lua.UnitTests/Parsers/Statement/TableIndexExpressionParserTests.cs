using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
{
    [TestFixture]
    public class TableIndexExpressionParserTests
    {
        private readonly LuaStatement _expected = new StatementBlock(new Assignment(new Variable("a"),
            new TableIndexExpression(new Variable("b"), new StringConstantExpression("c")), false));

        [Test]
        public void ShouldParseTableIndexingExpressionInDotForm()
        {
            var actual = SyntaxParser.Parse("a = b.c");
            Assert.AreEqual(_expected, actual);
        }

        [Test]
        public void ShouldParseTableIndexingExpressionInSquareBracketForm()
        {
            var actual = SyntaxParser.Parse("a = b[\"c\"]");
            Assert.AreEqual(_expected, actual);
        }
    }
}