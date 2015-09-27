using System.Collections.Generic;
using LuaParser.Exceptions;
using LuaParser.Extensions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class IfStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader, IParserContext context)
        {
            StatementBlock elseBlock = null;
            reader.VerifyExpectedTokenAndAdvance(Keyword.If);
            var conditionExpression = SyntaxParser.ReadExpression(reader);
            reader.VerifyExpectedTokenAndAdvance(Keyword.Then);

            var ifBlockParser = new StatementBlockParser(Keyword.End, Keyword.Else);
            var ifBlock = ifBlockParser.ParseBlock(reader);

            if (reader.Current == Keyword.Else)
            {
                var elseBlockParser = new StatementBlockParser(Keyword.End, Keyword.Else);
                reader.Advance();
                elseBlock = elseBlockParser.ParseBlock(reader);
            }
            reader.VerifyExpectedToken(Keyword.End);
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}