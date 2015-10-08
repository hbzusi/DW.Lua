using System.Text;
using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class StringConstantExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.DoubleQuote, LuaToken.DoubleLeftSquareBracket);
            var builder = new StringBuilder();
            while (reader.HasNext && reader.Current != LuaToken.DoubleQuote &&
                   reader.Current != LuaToken.DoubleRightSquareBracket)
                builder.Append(reader.GetAndMoveNext());
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.DoubleQuote, LuaToken.DoubleRightSquareBracket);

            return new StringConstantExpression(builder.ToString());
        }
    }
}