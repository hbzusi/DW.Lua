using LuaParser;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class WhileStatementParserTests
    {
        [Test]
        public void ShouldParseWhileBlock()
        {
            var expected = new StatementBlock(new WhileStatement(new ConstantExpression(Constants.True),new StatementBlock(new EmptyStatement())));
            var actual = SyntaxParser.Parse("while true do ; end");
            Assert.AreEqual(expected,actual);
        }
    }
}
