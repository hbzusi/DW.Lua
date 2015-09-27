﻿using System.Collections.Generic;
using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Syntax;

namespace DW.Lua.Parsers.Statement
{
    internal class StatementBlockParser : StatementParser
    {
        private readonly HashSet<string> _terminatingTokens;

        public StatementBlockParser(params string[] terminatingTokens)
            : this(Enumerable.AsEnumerable(terminatingTokens))
        {
        }

        public StatementBlockParser(IEnumerable<string> terminatingTokens)
        {
            _terminatingTokens = new HashSet<string>(terminatingTokens);
        }

        public override LuaStatement Parse(ITokenEnumerator reader, IParserContext context)
        {
            return ParseBlock(reader, context);
        }

        public StatementBlock ParseBlock(ITokenEnumerator reader, IParserContext context)
        {
            var statements = new List<LuaStatement>();
            while (!_terminatingTokens.Contains(reader.Current))
                statements.Add(SyntaxParser.ReadStatement(reader, context));
            reader.VerifyExpectedTokenAndAdvance(_terminatingTokens);
            return new StatementBlock(statements);
        }
    }
}