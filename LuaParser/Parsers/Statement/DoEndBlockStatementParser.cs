using System.Collections.Generic;
using LuaParser.Extensions;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Statement
{
    internal class DoEndBlockStatementParser : StatementParser
    {
        public override Syntax.LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedToken(Keyword.Do);
            reader.Advance();
            var statements = new List<Syntax.LuaStatement>();
            while (reader.Current != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader));
            reader.VerifyExpectedToken(Keyword.End);
            return new DoEndBlock(new StatementBlock(statements));
        }
    }
}