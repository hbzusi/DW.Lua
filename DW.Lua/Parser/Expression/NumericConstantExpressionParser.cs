using System;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Expression
{
    public class NumericConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var constantValue = Double.Parse(reader.Current.Value);
            reader.MoveNext();
            return new ConstantExpression(new Value {NumericValue = constantValue});
        }
    }
}