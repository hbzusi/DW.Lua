using System.Threading;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;

namespace DW.Lua.Parser.Statement
{
    internal static class StatementParserDiscriminator
    {
        public static IStatementParser Identify(INextAwareEnumerator<Token> reader)
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

            if (SyntaxParser.CurrentTokenIsTableIndexer(reader))
            {
                
            }
            // If nothing else, the statement is probably an assignment statement

            return new AssignmentStatementParser(local);
        }
    }
}