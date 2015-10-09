using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
{
    [TestFixture]
    public class DoEndBlockStatementParserTests
    {
        [Test]
        public void ShouldParseDoEnd()
        {
            var expected =
                new StatementBlock(new DoEndBlock(new StatementBlock(new EmptyStatement(), new EmptyStatement())));
            var actual = SyntaxParser.Parse("do ; ; end");
            Assert.AreEqual(expected,actual);
        }
    }
}
