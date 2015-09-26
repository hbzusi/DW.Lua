using LuaParser.Exceptions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class IfStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader)
        {
            StatementBlock ifBlock = new StatementBlock();
            StatementBlock elseBlock = null;

            if (reader.Current != Keyword.If)
                throw new UnexpectedTokenException(reader.Current);
            reader.Advance();
            var conditionExpression = SyntaxParser.ReadExpression(reader);
            if (reader.Current != Keyword.Then)
                throw new UnexpectedTokenException(reader.Current);

            reader.Advance();
            while (reader.Current != Keyword.End && reader.Current != Keyword.Else)
                ifBlock.Statements.Add(SyntaxParser.ReadStatement(reader));

            if (reader.Current == Keyword.Else)
            {
                reader.Advance();
                elseBlock = new StatementBlock();
                while (reader.Current != Keyword.End)
                    elseBlock.Statements.Add(SyntaxParser.ReadStatement(reader));
            }
            if (reader.Current != Keyword.End)
                throw new UnexpectedTokenException(reader.Current);
            return new IfStatement(conditionExpression, ifBlock, elseBlock);
        }
    }
}