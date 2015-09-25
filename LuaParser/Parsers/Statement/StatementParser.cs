namespace LuaParser.Parsers.Statement
{
    internal abstract class StatementParser
    {
        public abstract Syntax.Statement Parse(ITokenEnumerator reader);
    }
}