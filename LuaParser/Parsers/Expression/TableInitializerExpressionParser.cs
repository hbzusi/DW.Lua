using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class TableInitializerExpressionParser : ExpressionParser
    {
        public override LuaExpression Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(Token.LeftCurlyBrace);
            reader.Advance();
            var expressions = new List<LuaExpression>();
            while (reader.Current != Token.RightCurlyBrace)
            {
                expressions.Add(SyntaxParser.ReadExpression(reader, context));
                reader.VerifyExpectedToken(Token.RightCurlyBrace, Token.Comma);
            }
            reader.VerifyExpectedToken(Token.RightCurlyBrace);
            reader.Advance();
            return new TableInitializerExpression(expressions);
        }
    }
}