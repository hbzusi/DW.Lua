using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class DoEndBlockStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(Keyword.Do);
            reader.Advance();
            var statements = new List<LuaStatement>();
            while (reader.Current != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader, context));
            reader.VerifyExpectedTokenAndAdvance(Keyword.End);
            return new DoEndBlock(new StatementBlock(statements));
        }
    }
}