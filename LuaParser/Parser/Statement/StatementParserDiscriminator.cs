using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

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
            if (reader.Current.Value == Keyword.Function)
                return new FunctionDeclarationStatementParser();
            return new AssignmentStatementParser();
        }
    }

    internal class ReturnStatementParser : StatementParser
    {
        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keyword.Return);
            var returnedExpression = SyntaxParser.ReadExpression(reader, context);
            return new ReturnStatement(returnedExpression);
        }
    }
}