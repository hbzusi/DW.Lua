using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Control;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class IfStatementParser : IStatementParser
    {
        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            StatementBlock elseBlock = null;
            reader.VerifyExpectedTokenAndMoveNext(Keywords.If);
            var conditionExpression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Then);

            var ifBlockParser = new StatementBlockParser(Keywords.End, Keywords.Else);
            Token delimiterToken;
            var ifBlock = ifBlockParser.ParseBlock(reader, context, out delimiterToken);

            if (delimiterToken.Value == Keywords.Else)
            {
                var elseBlockParser = new StatementBlockParser(Keywords.End);
                elseBlock = elseBlockParser.ParseBlock(reader, context);
            }
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}