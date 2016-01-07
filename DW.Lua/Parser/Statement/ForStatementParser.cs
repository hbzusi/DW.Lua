using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Language;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Parser.Expression;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class ForStatementParser : IStatementParser
    {
        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keywords.For);
            var scope = context.AcquireScope();
            reader.VerifyIsIdentifier();
            var forVariableName = reader.GetAndMoveNext();
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.EqualsSign);
            var conditionsParser = new ExpressionListParser();
            var conditions = conditionsParser.Parse(reader, context).ToList();
            reader.VerifyExpectedTokenAndMoveNext(Keywords.Do);

            var statementsParser = new StatementBlockParser(Keywords.End);
            var bodyBlock = statementsParser.ParseBlock(reader, context);
            context.ReleaseScope(scope);
            return new ForStatement(conditions,bodyBlock);
        }
    }
}