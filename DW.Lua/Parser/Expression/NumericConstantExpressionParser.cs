using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public sealed class NumericConstantExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var constantValue = double.Parse(reader.Current.Value);
            reader.MoveNext();
            return new ConstantExpression(new LuaValue {NumericValue = constantValue});
        }
    }
}