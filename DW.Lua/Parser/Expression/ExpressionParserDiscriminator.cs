using DW.Lua.Exceptions;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Expression;
using JetBrains.Annotations;
using System;

namespace DW.Lua.Parser.Expression
{
    public static class ExpressionParserDiscriminator
    {
        public static IExpressionParser Identify(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            if (reader.Current.Type == TokenType.StringConstant)
                return new StringConstantExpressionParser();

            if (LuaToken.IsIdentifier(reader.Current.Value) && reader.HasNext &&
                (reader.Next.Value == LuaToken.Dot || reader.Next.Value == LuaToken.LeftSquareBracket))
                TableExpressionParserDiscriminator.Identify(reader, context);

            if (reader.Current.Value == LuaToken.LeftBracket)
                return new BracketedExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value) && reader.HasNext &&
                reader.Next.Value == LuaToken.LeftBracket)
                return new FunctionCallExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value) && reader.HasNext &&
                reader.Next.Value == LuaToken.Colon)
                return new MethodCallExpressionParser();
            if (reader.Current.Type == TokenType.BooleanConstant)
                return new BooleanConstantExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value))
                return new SingleVariableExpressionParser();
            if (LuaToken.IsNumericConstant(reader.Current.Value))
                return new NumericConstantExpressionParser();
            if (reader.Current.Value == LuaToken.LeftCurlyBrace)
                return new TableInitializerExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }

    public static class TableExpressionParserDiscriminator
    {
        public static IExpressionParser Identify(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            return new TableIndexExpressionParser();
            //var tableExpression = new TableIndexExpressionParser().Parse(reader, context);
            //if (reader.HasNext && reader.Next.Value == LuaToken.LeftBracket)
            //    return new FunctionCallExpressionParser();

            //throw new NotImplementedException();
        }
    }

    public class IdentityExpressionParser :IExpressionParser
    {
        private readonly LuaExpression _expression;

        public IdentityExpressionParser(LuaExpression expression)
        {
            _expression = expression;
        }

        public LuaExpression Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            return _expression;
        }
    }
}