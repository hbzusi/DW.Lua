namespace DW.Lua.Lexer
{
    public enum TokenType
    {
        StringConstant,
        NumericConstant,
        BooleanOperator,
        ArithmeticOperator,
        TableCall,
        TableSelfCall,
        Keyword,
        Identifier,
        Comment,
        BooleanConstant
    }
}