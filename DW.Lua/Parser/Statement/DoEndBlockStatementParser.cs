using System.Collections.Generic;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Statement
{
    internal class DoEndBlockStatementParser : StatementParser
    {
        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            var scope = context.AcquireScope();
            reader.VerifyExpectedToken(Keyword.Do);
            reader.MoveNext();
            var statements = new List<LuaStatement>();
            while (reader.Current.Value != Keyword.End)
                statements.Add(SyntaxParser.ReadStatement(reader, context));
            reader.VerifyExpectedTokenAndMoveNext(Keyword.End);
            context.ReleaseScope(scope);
            return new DoEndBlock(new StatementBlock(statements));
        }
    }
}