using LuaParser;
using LuaParser.Exceptions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class IfStatementParserTests
    {
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

        [Test]
        public void ShouldFailOnEndAfterIf()
        {
            Assert.Throws<UnexpectedTokenException>(() => SyntaxParser.Parse("if true end"));
        }
    }
}