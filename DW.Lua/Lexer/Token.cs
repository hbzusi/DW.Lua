namespace DW.Lua.Lexer
{
    public class Token
    {
        public TokenPosition Position { get; }

        public Token(string value, TokenPosition position, TokenType type)
        {
            Position = position;
            Value = value;
            Type = type;
        }

        public string Value { get; }

        public TokenType Type { get; }
    }
}
