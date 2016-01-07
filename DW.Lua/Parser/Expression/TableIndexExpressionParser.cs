using System;
using System.Collections.Generic;
using System.Linq;
using DW.Lua.Exceptions;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;

namespace DW.Lua.Parser.Expression
{
    public class TableIndexExpressionParser : IExpressionParser
    {
        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var tableName = reader.Current.Value;
            LuaExpression indexerExpression;
            reader.MoveNext();
            if (reader.Current.Value == LuaToken.Dot)
            {
                reader.MoveNext();
                indexerExpression = new StringConstantExpression(reader.Current.Value);
            }
            else if (reader.Current.Value == LuaToken.LeftSquareBracket)
            {
                reader.MoveNext();
                indexerExpression = SyntaxParser.ReadExpression(reader, context);
            }
            else
                throw new UnexpectedTokenException(reader.Current, LuaToken.Dot, LuaToken.LeftSquareBracket);
            return new TableIndexExpression(new Variable(tableName), indexerExpression);
        }
    }
}
