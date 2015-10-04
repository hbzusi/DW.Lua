using DW.Lua.Syntax;
using DW.Lua.Syntax.Control;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
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
