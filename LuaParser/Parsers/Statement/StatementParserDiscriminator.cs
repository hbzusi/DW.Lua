using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(ITokenEnumerator reader)
        {
            if (reader.Current == Keyword.If)
                return new IfStatementParser();
            if (reader.Current == Keyword.While)
                return new WhileStatementParser();
            if (reader.Current == LuaToken.Semicolon)
                return new EmptyStatementParser();
            if (reader.Current == Keyword.Do)
                return new DoEndBlockStatementParser();
            if (reader.Current == Keyword.Function)
                return new FunctionDeclarationStatementParser();
            return new AssignmentStatementParser();
        }
    }
}