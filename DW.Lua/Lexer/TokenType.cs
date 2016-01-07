namespace DW.Lua.Lexer
{
    public enum TokenType
    {
        StringConstant,
        NumericConstant,
        BooleanOperator,
        ArithmeticOperator,
        TableIndexer,
        TableShortcutIndexer,
        Keyword,
        Identifier,
        Comment,
        BooleanConstant
    }
}