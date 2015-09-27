using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaParser;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;
using NUnit.Framework;

namespace LuaParserUnitTests.Parsers.Statement
{
    [TestFixture]
    public class WhileStatementParserTests
    {
        [Test]
        public void ShouldParseWhileBlock()
        {
            var booleanTrue = new Value() {BooleanValue = true};
            var expected = new StatementBlock(new WhileStatement(new ConstantExpression(booleanTrue),new StatementBlock(new EmptyStatement())));
            var actual = SyntaxParser.Parse("while true do ; end");
            Assert.AreEqual(expected,actual);
        }
    }
}
