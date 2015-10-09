using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Syntax.Statement;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Statement
{
    [TestFixture]
    public class AssignmentStatementParserTests
    {
        [Test]
        public void ShouldParseLocalAssignment()
        {
            var assignment = new Assignment(new[] {new Variable("a")},
                new[] {new ConstantExpression(Constants.One)}, true);
            var expected = new StatementBlock(assignment);
            var actual = SyntaxParser.Parse("local a = 1");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldParseSimpleAssignment()
        {
            var assignment = new Assignment(new[] {new Variable("a")},
                new[] {new ConstantExpression(Constants.One)}, false);
            var expected = new StatementBlock(assignment);
            Assert.AreEqual(expected, SyntaxParser.Parse("a = 1"));
        }

        [Test]
        public void ShouldParseSequentialAssignments()
        {
            var assignment1 = new Assignment(new[] { new Variable("a") },
                new[] { new ConstantExpression(Constants.One) }, true);
            var assignment2 = new Assignment(new[] { new Variable("b") },
                new[] { new ConstantExpression(Constants.Two) }, true);
            var expected = new StatementBlock(assignment1, assignment2);
            Assert.AreEqual(expected, SyntaxParser.Parse("local a = 1\nlocal b = 2"));
        }

        [Test]
        public void ShouldParseMultipleAssignments()
        {
            var assignment = new Assignment(new[] { new Variable("a"), new Variable("b") },
                new[] { new ConstantExpression(Constants.One) }, true);
            var expected = new StatementBlock(assignment);
            Assert.AreEqual(expected, SyntaxParser.Parse("local a,b = 1"));
        }
    }
}