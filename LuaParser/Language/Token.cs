namespace DW.Lua.Token
{
    public class Token
    {
        public Token(string value, int startPosition, int endPosition, TokenType tokenType)
        {
            Value = value;
            StartPosition = startPosition;
            EndPosition = endPosition;
            TokenType = tokenType;
        }

        public string Value { get; }

        public int StartPosition { get; }

        public int EndPosition { get; }

        public TokenType TokenType { get; }
    }

    public enum TokenType
    {
        StringConstant,
        NumericConstant,
        BooleanOperator,
        ArithmeticOperator,
        Keyword,
        Identifier
    }
}
