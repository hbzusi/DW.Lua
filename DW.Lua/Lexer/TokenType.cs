namespace DW.Lua.Lexer
{
    public enum TokenType
    {
        StringConstant,
        NumericConstant,
        BooleanOperator,
        ArithmeticOperator,
        TableIndexer,
        Keyword,
        Identifier,
        Comment,
        BooleanConstant
    }
}