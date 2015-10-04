using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parsers.Expression
{
    public class TableInitializerExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(LuaToken.LeftCurlyBrace);
            reader.Advance();
            var expressions = new List<LuaExpression>();
            while (reader.Current != LuaToken.RightCurlyBrace)
            {
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
                reader.VerifyExpectedToken(LuaToken.RightCurlyBrace, LuaToken.Comma);
            }
            reader.VerifyExpectedToken(LuaToken.RightCurlyBrace);
            reader.Advance();
            return new TableInitializerExpression(expressions);
        }
    }
}