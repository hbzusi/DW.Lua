using System.Threading;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(INextAwareEnumerator<Token> reader)
        {
            if (reader.Current.Value == Keyword.If)
                return new IfStatementParser();
            if (reader.Current.Value == Keyword.While)
                return new WhileStatementParser();
            if (reader.Current.Value == Keyword.Return)
                return new ReturnStatementParser();
            if (reader.Current.Value == Keyword.For)
                return new ForStatementParser();
            if (reader.Current.Value == LuaToken.Semicolon)
                return new EmptyStatementParser();
            if (reader.Current.Value == Keyword.Do)
                return new DoEndBlockStatementParser();

            bool local = false;
            if (reader.Current.Value == Keyword.Local)
            {
                local = true;
                reader.MoveNext();
            }

            if (reader.Current.Value == Keyword.Function)
                return new FunctionDeclarationStatementParser(local);
            return new AssignmentStatementParser(local);
        }
    }
}