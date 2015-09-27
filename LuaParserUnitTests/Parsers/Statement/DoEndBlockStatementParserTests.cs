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
