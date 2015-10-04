using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parsers.Statement
{
    internal class DoEndBlockStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            var scope = context.AcquireScope();
            reader.VerifyExpectedToken(Keyword.Do);
            reader.MoveNext();
            var statements = new List<LuaStatement>();
            while (reader.Current != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader, context));
            reader.VerifyExpectedTokenAndAdvance(Keyword.End);
            context.ReleaseScope(scope);
            return new DoEndBlock(new StatementBlock(statements));
        }
    }
}