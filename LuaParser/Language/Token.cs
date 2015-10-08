namespace DW.Lua.Language
{
    public class Token
    {
        public TokenPosition Position { get; }

        public Token(string value, TokenPosition position, TokenType tokenType)
        {
            Position = position;
            Value = value;
            TokenType = tokenType;
        }

        public string Value { get; }

        public TokenType TokenType { get; }
    }

    public struct TokenPosition
    {
        public TokenPosition(int lineNumber, int startPosition, int endPosition)
        {
            LineNumber = lineNumber;
            StartPosition = startPosition;
            EndPosition = endPosition;
        }

        public int StartPosition { get; }

        public int EndPosition { get; }

        public int LineNumber { get; }

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
