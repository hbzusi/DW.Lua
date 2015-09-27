using DW.Lua.Syntax;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
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
