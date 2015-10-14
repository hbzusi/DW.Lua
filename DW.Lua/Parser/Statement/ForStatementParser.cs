using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using DW.Lua.Parser.Expression;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;
using DW.Lua.Tokenizer;

namespace DW.Lua.Parser.Statement
{
    internal class ForStatementParser : StatementParser
    {
        public override LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
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
            context.ReleaseScope(scope);
            return new ForStatement(conditions,bodyBlock);
        }
    }
}