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
}
