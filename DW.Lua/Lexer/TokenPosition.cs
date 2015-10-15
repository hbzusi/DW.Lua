namespace DW.Lua.Lexer
{
    public struct TokenPosition
    {
        public TokenPosition(int lineNumber, int startPosition, int column)
        {
            LineNumber = lineNumber;
            StartPosition = startPosition;
            Column = column;
        }

        private int StartPosition { get; }

        private int Column { get; }

        private int LineNumber { get; }

        public override string ToString()
        {
            return $"Ln {LineNumber} Col {Column}";
        }
    }
}