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
            Assert.AreEqual(expected, SyntaxParser.Parse("do ; ; end"));
        }
    }
}
