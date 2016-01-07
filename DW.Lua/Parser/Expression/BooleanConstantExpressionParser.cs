using System;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public sealed class BooleanConstantExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var expression = new ConstantExpression(new LuaValue { BooleanValue = Boolean.Parse(reader.Current.Value) });
            reader.MoveNext();
            return expression;
        }
    }
}