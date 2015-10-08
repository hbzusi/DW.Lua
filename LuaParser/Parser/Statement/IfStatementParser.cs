using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Control;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal class IfStatementParser : StatementParser
    {
        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            StatementBlock elseBlock = null;
            reader.VerifyExpectedTokenAndMoveNext(Keyword.If);
            var conditionExpression = SyntaxParser.ReadExpression(reader, context);
            reader.VerifyExpectedTokenAndMoveNext(Keyword.Then);

            var ifBlockParser = new StatementBlockParser(Keyword.End, Keyword.Else);
            var ifBlock = ifBlockParser.ParseBlock(reader, context);

            if (reader.Current.Value == Keyword.Else)
            {
                var elseBlockParser = new StatementBlockParser(Keyword.End);
                elseBlock = elseBlockParser.ParseBlock(reader, context);
            }
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}