using System.Linq;
using LuaParser;
using LuaParser.Parsers.Expression;
using LuaParser.Syntax;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class AssignmentStatementParserTests
    {
        [Test]
        public void ShouldParseSimpleAssignment()
        {
            var assignment = new Assignment(new[] {new Variable("a")},
                new[] {new ConstantExpression(new Value {NumericValue = 1})}, false);
            var expected = new StatementBlock(new[] {assignment});
            Assert.AreEqual(expected, SyntaxParser.Parse("a = 1"));
        }

        [Test]
        public void ShouldParseLocalAssignment()
        {
            var assignment = new Assignment(new[] { new Variable("a") },
                new[] { new ConstantExpression(new Value { NumericValue = 1 }) }, true);
            var expected = new StatementBlock(new[] { assignment });
            Assert.AreEqual(expected, SyntaxParser.Parse("local a = 1"));
        }
    }
}
