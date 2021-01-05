using System.Collections.Generic;

using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class TableFieldInitializerExpressionListParser
    {
        public IEnumerable<LuaExpression> Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var expressions = new List<LuaExpression>();
            do
            {
                while (string.IsNullOrEmpty(reader.Current.Value)
                   || reader.Current.Value == "\n"
                   || reader.Current.Type == TokenType.Comment)
                    reader.MoveNext();
                if (reader.Current.Value == LuaToken.RightCurlyBrace)
                    break;
                
                LuaExpression indexerExpression = null;
                if (reader.Current.Value == LuaToken.LeftSquareBracket)
                {
                    reader.MoveNext();
                    indexerExpression = SyntaxParser.ReadExpression(reader, context);
                    reader.VerifyExpectedTokenAndMoveNext(LuaToken.RightSquareBracket);
                }
                else if (LuaToken.IsIdentifier(reader.Current.Value))
                {
                    indexerExpression = new StringConstantExpression(reader.Current.Value);
                    reader.MoveNext();
                }
                if (indexerExpression != null)
                {
                    reader.VerifyExpectedTokenAndMoveNext(LuaToken.EqualsSign);
                }
                
                var valueExpression = SyntaxParser.ReadExpression(reader, context);
                if (indexerExpression != null)
                {
                    expressions.Add(new TableFieldInitializerExpression(new Variable(string.Empty), indexerExpression, valueExpression));
                }
                else
                {
                    expressions.Add(valueExpression);
                }
            } while ((reader.Current.Value == LuaToken.Comma || reader.Current.Value == LuaToken.Semicolon) && reader.MoveNext());
            
            while (string.IsNullOrEmpty(reader.Current.Value)
               || reader.Current.Value == "\n"
               || reader.Current.Type == TokenType.Comment)
                reader.MoveNext();
            
            return expressions;
        }
    }
}