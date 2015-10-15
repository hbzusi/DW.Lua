using System.Threading;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Statement
{
    internal class StatementParserDiscriminator
    {
        public StatementParser Identify(INextAwareEnumerator<Token> reader)
        {
            if (reader.Current.Value == Keywords.If)
                return new IfStatementParser();
            if (reader.Current.Value == Keywords.While)
                return new WhileStatementParser();
            if (reader.Current.Value == Keywords.Return)
                return new ReturnStatementParser();
            if (reader.Current.Value == Keywords.For)
                return new ForStatementParser();
            if (reader.Current.Value == LuaToken.Semicolon)
                return new EmptyStatementParser();
            if (reader.Current.Value == Keywords.Do)
                return new DoEndBlockStatementParser();

            bool local = false;
            if (reader.Current.Value == Keywords.Local)
            {
                local = true;
                reader.MoveNext();
            }

            if (reader.Current.Value == Keywords.Function)
                return new FunctionDeclarationStatementParser(local);
            return new AssignmentStatementParser(local);
        }
    }
}