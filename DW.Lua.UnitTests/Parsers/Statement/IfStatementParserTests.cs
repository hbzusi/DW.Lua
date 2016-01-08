using DW.Lua.Exceptions;
using DW.Lua.Syntax.Control;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
{
    [TestFixture]
    public class IfStatementParserTests
    {
        [Test]
        public void ShouldFailOnEndAfterIf()
        {
            Assert.Throws<UnexpectedTokenException>(() => SyntaxParser.Parse("if true end"));
        }

        [Test]
        public void ShouldParseIfElseThen()
        {
            var conditionExpression = new BracketedExpression(new ConstantExpression(Constants.True));
            var emptyStatementBlock = new StatementBlock(new EmptyStatement());
            var ifStatement = new IfStatement(conditionExpression, emptyStatementBlock, emptyStatementBlock);
            var expected = new StatementBlock(ifStatement);
            var actual = SyntaxParser.Parse("if (true) then ; else ; end");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldParseIfThen()
        {
            var conditionExpression = new BracketedExpression(new ConstantExpression(Constants.False));
            var emptyStatementBlock = new StatementBlock(new EmptyStatement());
            var ifStatement = new IfStatement(conditionExpression, emptyStatementBlock);
            var expected = new StatementBlock(ifStatement);
            Assert.AreEqual(expected, SyntaxParser.Parse("if (false) then ; end"));
        }
    }
}