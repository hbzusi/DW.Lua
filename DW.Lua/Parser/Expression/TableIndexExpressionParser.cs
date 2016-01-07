using System;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
{
    public class TableIndexExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            throw new NotImplementedException();
        }
    }
}
