using LuaParser;
using LuaParser.Exceptions;
using LuaParser.Parsers.Expression;
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
            var value = new Value {BooleanValue = true};
            var conditionExpression = new BracketedExpression(new ConstantExpression(value));
            var emptyStatementBlock = new StatementBlock(new EmptyStatement());
            var ifStatement = new IfStatement(conditionExpression, emptyStatementBlock, emptyStatementBlock);
            var expected = new StatementBlock(ifStatement);
            Assert.AreEqual(expected, SyntaxParser.Parse("if (true) then ; else ; end"));
        }

        [Test]
        public void ShouldParseIfThen()
        {
            var value = new Value {BooleanValue = false};
            var conditionExpression = new BracketedExpression(new ConstantExpression(value));
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