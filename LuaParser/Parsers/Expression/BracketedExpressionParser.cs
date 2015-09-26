using System;
using System.Collections.Generic;
using LuaParser.Syntax;

namespace LuaParser.Parsers.Expression
{
    public class BracketedExpressionParser : ExpressionParser
    {
        public override Syntax.Expression Parse(ITokenEnumerator reader)
        {
            if (reader.Current != Token.LeftBracket)
                throw new InvalidOperationException("Bracketed exception parser called on non-bracket token");
            reader.Advance();
            var expression = SyntaxParser.ReadExpression(reader);
            if (reader.Current != Token.RightBracket)
                throw new InvalidOperationException("Bracketed exception parser called on non-bracket token");
            reader.Advance();
            return new BracketedExpression(expression);
        }
    }

    public class BracketedExpression : Syntax.Expression
    {
        public BracketedExpression(Syntax.Expression expression)
        {
            Contents = expression;
        }

        public override IEnumerable<Unit> Children => new[] {Contents};
        public Syntax.Expression Contents { get; }
    }
}