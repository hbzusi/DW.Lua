namespace LuaParser.Syntax.Control
{
    class RepeatUntilBlock
    {
        public Expression Condition { get; set; }
        public StatementBlock StatementBlock { get; set; }
    }
}