using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaParser;
using NUnit.Framework;

namespace LuaParserUnitTests.Parser
{
    [TestFixture]
    public class IfStatementParserTests
    {
        [Test]
        public void Test()
        {
            SyntaxParser.Parse("if (true) then ; else ; end");
        } 
    }
}
