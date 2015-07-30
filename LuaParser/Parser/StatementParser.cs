using LuaParser.Syntax;

namespace LuaParser.Parser
{
    internal abstract class StatementParser
    {
        public abstract Statement Parse(TokenEnumerator reader);
    }
}