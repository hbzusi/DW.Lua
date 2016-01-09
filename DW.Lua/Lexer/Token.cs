namespace DW.Lua.Lexer
{
    public class Token
    {
        public Token(string value, TokenPosition position, TokenType type)
        {
            Position = position;
            Value = value;
            Type = type;
        }

        public TokenPosition Position { get; }

        public string Value { get; }

        public TokenType Type { get; }
    }
}