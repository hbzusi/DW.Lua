using DW.Lua.Exceptions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Expression
{
    public static class ExpressionParserDiscriminator
    {
        public static IExpressionParser Identify(INextAwareEnumerator<Token> reader)
        {
            if (reader.Current.Value == LuaToken.LeftBracket)
                return new BracketedExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value) && reader.Next.Value == LuaToken.LeftBracket)
                return new FunctionCallExpressionParser();
            if (reader.Current.Type == TokenType.BooleanConstant)
                return new BooleanConstantExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value))
                return new SingleVariableExpressionParser();
            if (LuaToken.IsNumericConstant(reader.Current.Value))
                return new NumericConstantExpressionParser();
            if (reader.Current.Value == LuaToken.LeftCurlyBrace)
                return new TableInitializerExpressionParser();
            if (reader.Current.Type == TokenType.StringConstant)
                return new StringConstantExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }
}