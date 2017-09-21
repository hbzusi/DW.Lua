using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
{
    [TestFixture]
    public class FunctionDeclarationStatementParserTests
    {
        [Test]
        public void ShouldParseNoArgumentsFunctionDeclaration()
        {
            var expected = new StatementBlock(new FunctionDeclarationStatement("func", new string[0],
                new StatementBlock(new EmptyStatement())));

            var actual = SyntaxParser.Parse("function func() ; end");
            Assert.AreEqual(expected, actual);
        }

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