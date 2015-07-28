using LuaParser.Syntax;

namespace LuaParser.Control
{
    class RepeatUntilBlock
    {
        public Expression Condition { get; set; }
        public Block Block { get; set; }
    }
}