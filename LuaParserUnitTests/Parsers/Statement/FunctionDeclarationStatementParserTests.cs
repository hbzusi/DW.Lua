using LuaParser;
using LuaParser.Parsers.Statement;
using LuaParser.Syntax;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class FunctionDeclarationStatementParserTests
    {
        [Test]
        public void ShouldParseSimpleFunctionDeclaration()
        {
            var expected = new StatementBlock(new FunctionDeclarationStatement("func", new[] {"arg1", "arg2"},
                new StatementBlock(new EmptyStatement())));

            var actual = SyntaxParser.Parse("function func(arg1,arg2) ; end");
            Assert.AreEqual(expected, actual);
        }
    }
}
