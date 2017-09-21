using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class ReturnStatementParser : IStatementParser
    {
        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Return);
            var returnedExpression = SyntaxParser.ReadExpression(reader, context);
            return new ReturnStatement(returnedExpression);
        }
    }
}