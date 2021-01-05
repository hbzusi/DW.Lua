using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Lexer;
using DW.Lua.Misc;
using DW.Lua.Syntax;
using DW.Lua.Syntax.Statement;

namespace DW.Lua.Parser.Statement
{
    internal sealed class StatementBlockParser : IStatementParser
    {
        private readonly HashSet<string> _terminatingTokens;

        public StatementBlockParser(params string[] terminatingTokens)
            : this(terminatingTokens.AsEnumerable())
        {
        }

        public StatementBlockParser(IEnumerable<string> terminatingTokens)
        {
            _terminatingTokens = new HashSet<string>(terminatingTokens);
        }

        public LuaStatement Parse(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            return ParseBlock(reader, context);
        }

        public StatementBlock ParseBlock(INextAwareEnumerator<Token> reader, IParserContext context)
        {
            Token terminationToken;
            return ParseBlock(reader, context, out terminationToken);
        }

        public StatementBlock ParseBlock(INextAwareEnumerator<Token> reader, IParserContext context,
            out Token terminationToken)
        {
            var statements = new List<LuaStatement>();
            while (!_terminatingTokens.Contains(reader.Current.Value))
            {
                statements.Add(SyntaxParser.ReadStatement(reader, context));
                while (string.IsNullOrEmpty(reader.Current.Value) || reader.Current.Value == "\n")
                {
                    if (!reader.MoveNext())
                    {
                        terminationToken = null;
                        return new StatementBlock(statements);
                    }
                }
            }
            terminationToken = reader.Current;
            reader.VerifyExpectedTokenAndMoveNext(_terminatingTokens);
            return new StatementBlock(statements);
        }
    }
}