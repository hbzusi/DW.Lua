using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Parsers.Expression
{
    public static class TableFunctionCallExpressionParserTests
    {
        [Test]
        public static void ShouldParseTableFunctionCallNoArguments()
        {
            var expected = new TableFunctionCallExpression(new Variable("b"), new StringConstantExpression("c"));
            var actual = Helpers.ParseExpression("b.c()");
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public static void ShouldParseTableFunctionCallWithArguments()
        {
            var expected = new TableFunctionCallExpression(new Variable("b"), new StringConstantExpression("c"),
                new VariableExpression(new Variable("d")),
                new StringConstantExpression("e"),
                new ConstantExpression(Constants.Two));
            var actual = Helpers.ParseExpression("b.c(d,\"e\",2)");
            Assert.AreEqual(expected, actual);
        }
    }
}
