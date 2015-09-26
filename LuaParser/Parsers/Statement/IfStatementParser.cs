using System.Collections.Generic;
using LuaParser.Exceptions;
using LuaParser.Extensions;
using LuaParser.Syntax;
using LuaParser.Syntax.Control;

namespace LuaParser.Parsers.Statement
{
    internal class IfStatementParser : StatementParser
    {
        public override Syntax.Statement Parse(ITokenEnumerator reader)
        {
            var ifStatements = new List<Syntax.Statement>();
            StatementBlock elseBlock = null;
            reader.VerifyExpectedToken(Keyword.If);
            reader.Advance();
            var conditionExpression = SyntaxParser.ReadExpression(reader);
            reader.VerifyExpectedToken(Keyword.Then);
            reader.Advance();
            while (reader.Current != Keyword.End && reader.Current != Keyword.Else)
                ifStatements.Add(SyntaxParser.ReadStatement(reader));

            if (reader.Current == Keyword.Else)
            {
                reader.Advance();
                var elseStatements = new List<Syntax.Statement>();
                while (reader.Current != Keyword.End)
                    elseStatements.Add(SyntaxParser.ReadStatement(reader));
                elseBlock = new StatementBlock(elseStatements);
            }
            reader.VerifyExpectedToken(Keyword.End);
            return new IfStatement(conditionExpression, new StatementBlock(ifStatements), elseBlock);
        }
    }
}