using DW.Lua.Exceptions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Expression
{
    public class ExpressionParserDiscriminator
    {
        public ExpressionParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == LuaToken.LeftBracket)
                return new BracketedExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current) && reader.Next == LuaToken.LeftBracket)
                return new FunctionCallExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current) && LuaToken.IsBinaryOperation(reader.Next))
                return new BinaryOperationExpressionParser();
            if (LuaToken.IsBooleanConstant(reader.Current))
                return new BooleanConstantExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current))
                return new SingleVariableExpressionParser();
            if (LuaToken.IsNumericConstant(reader.Current))
                return new NumericConstantExpressionParser();
            if (reader.Current == LuaToken.LeftCurlyBrace)
                return new TableInitializerExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }
}