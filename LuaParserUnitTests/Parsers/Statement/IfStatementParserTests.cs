using LuaParser;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class IfStatementParserTests
    {
        private const string EmptyIfCase = "if (true) then ; end";
        private const string EmptyIfElseCase = "if (true) then ; else ; end";

        [Test]
        [TestCase(EmptyIfCase)]
        [TestCase(EmptyIfElseCase)]
        public void Test(string code)
        {
            SyntaxParser.Parse(code);
        } 
    }
}
