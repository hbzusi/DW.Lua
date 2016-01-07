using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW.Lua.Lexer;
using DW.Lua.Parser;
using DW.Lua.Syntax;

namespace DW.Lua.UnitTests
{
    internal static class Helpers
    {
        internal static LuaExpression ParseExpression(string expressionString)
        {
            var tokensStream = Tokenizer.Parse(new StringReader(expressionString));
            var context = new ParserContext(new Scope());
            return SyntaxParser.ReadExpression(tokensStream, context);
        }
    }
}
