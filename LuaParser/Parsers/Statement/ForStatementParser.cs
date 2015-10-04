using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Parsers.Expression;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parsers.Statement
{
    internal class ForStatementParser : StatementParser
    {
        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            reader.VerifyExpectedTokenAndMoveNext(Keyword.For);
            var scope = context.AcquireScope();
            reader.VerifyIsIdentifier();
            var forVariableName = reader.GetAndMoveNext();
            reader.VerifyExpectedTokenAndMoveNext(LuaToken.EqualsSign);
            var conditionsParser = new ExpressionListParser();
            var conditions = conditionsParser.Parse(reader, context).ToList();
            reader.VerifyExpectedTokenAndMoveNext(Keyword.Do);

            var statementsParser = new StatementBlockParser(Keyword.End);
            var bodyBlock = statementsParser.ParseBlock(reader, context);
            return new ForStatement(conditions,bodyBlock);
        }
    }
}