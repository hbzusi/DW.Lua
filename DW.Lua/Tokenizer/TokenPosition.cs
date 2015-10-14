namespace DW.Lua.Tokenizer
{
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
}