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
            reader.VerifyExpectedTokenAndMoveNext(Keywords.If);
            return ParseInternal(reader, context);
        }

        private LuaStatement ParseInternal(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var conditionExpression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Then);

            var ifBlockParser = new StatementBlockParser(Keywords.End, Keywords.Else, Keywords.ElseIf);
            Token delimiterToken;
            var ifBlock = ifBlockParser.ParseBlock(reader, context, out delimiterToken);

            StatementBlock elseBlock = null;
            if (delimiterToken.Value == Keywords.Else)
            {
                var elseBlockParser = new StatementBlockParser(Keywords.End);
                elseBlock = elseBlockParser.ParseBlock(reader, context);
            }
            else if (delimiterToken.Value == Keywords.ElseIf)
            {
                elseBlock = new StatementBlock(ParseInternal(reader, context));
            }
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}