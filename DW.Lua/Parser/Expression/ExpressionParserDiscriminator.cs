using DW.Lua.Exceptions;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Expression
{
    public class ExpressionParserDiscriminator
    {
        public ExpressionParser Identify(INextAwareEnumerator<Token> reader)
        {
            if (reader.Current.Value == LuaToken.LeftBracket)
                return new BracketedExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value) && reader.Next.Value == LuaToken.LeftBracket)
                return new FunctionCallExpressionParser();
            if (LuaToken.IsBooleanConstant(reader.Current.Value))
                return new BooleanConstantExpressionParser();
            if (LuaToken.IsIdentifier(reader.Current.Value))
                return new SingleVariableExpressionParser();
            if (LuaToken.IsNumericConstant(reader.Current.Value))
                return new NumericConstantExpressionParser();
            if (reader.Current.Value == LuaToken.LeftCurlyBrace)
                return new TableInitializerExpressionParser();
            if (reader.Current.Value.StartsWith(LuaToken.DoubleQuote))
                return new StringConstantExpressionParser();
            throw new UnexpectedTokenException(reader.Current);
        }
    }
}