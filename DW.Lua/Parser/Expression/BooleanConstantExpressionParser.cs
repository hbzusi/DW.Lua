using System;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Expression
{
    public class BooleanConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var expression = new ConstantExpression(new Value { BooleanValue = Boolean.Parse(reader.Current.Value) });
            reader.MoveNext();
            return expression;
        }
    }
}