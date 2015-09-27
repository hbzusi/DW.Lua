using LuaParser;
using LuaParser.Syntax;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
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
