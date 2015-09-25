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
        private const string SimpleAssignmentCode = "a = 1";
        private const string LocalAssignmentCode = "local a = 1";

        [Test]
        [TestCase(SimpleAssignmentCode)]
        [TestCase(LocalAssignmentCode)]
        public void ShouldParseAsSingleAssignment(string code)
        {
            var statementBlock = SyntaxParser.Parse(code);
            Assert.That(statementBlock.Statements.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<Assignment>(statementBlock.Statements.Single());
        }

        [Test]
        [TestCase(SimpleAssignmentCode)]
        [TestCase(LocalAssignmentCode)]
        public void ShouldCorrectlyParseVariableName(string code)
        {
            var statementBlock = SyntaxParser.Parse(code);
            var assignment = (Assignment)statementBlock.Statements.Single();
            Assert.That(assignment.Variables.Count, Is.EqualTo(1));
            Assert.That(assignment.Variables.Single().Name, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(SimpleAssignmentCode,ExpectedResult = false)]
        [TestCase(LocalAssignmentCode,ExpectedResult = true)]
        public bool ShouldCorrectlyDistinguishLocalAssignments(string code)
        {
            var statementBlock = SyntaxParser.Parse(code);
            var assignment = (Assignment)statementBlock.Statements.Single();
            return assignment.Local;
        }

        [Test]
        [TestCase(SimpleAssignmentCode)]
        [TestCase(LocalAssignmentCode)]
        public void ShouldParseAssignedNumericConstantExpression(string code)
        {
            var statementBlock = SyntaxParser.Parse(code);
            var assignment = (Assignment)statementBlock.Statements.Single();

            Assert.That(assignment.Expressions.Count, Is.EqualTo(1));
            Assert.IsInstanceOf<NumericConstantExpression>(assignment.Expressions.Single());
            var expression = (NumericConstantExpression) assignment.Expressions.Single();
            Assert.That(expression.Value, Is.EqualTo(1));
        }
    }
}
