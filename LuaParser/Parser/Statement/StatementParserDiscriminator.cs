using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

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
            if (reader.Current == Keyword.Return)
                return new ReturnStatementParser();
            if (reader.Current == Keyword.For)
                return new ForStatementParser();
            if (reader.Current == LuaToken.Semicolon)
                return new EmptyStatementParser();
            if (reader.Current == Keyword.Do)
                return new DoEndBlockStatementParser();
            if (reader.Current == Keyword.Function)
                return new FunctionDeclarationStatementParser();
            return new AssignmentStatementParser();
        }
    }

    internal class ReturnStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keyword.Return);
            var returnedExpression = SyntaxParser.ReadExpression(reader, context);
            return new ReturnStatement(returnedExpression);
        }
    }
}