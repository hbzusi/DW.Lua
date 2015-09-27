using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
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