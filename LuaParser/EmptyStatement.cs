using System.Collections.Generic;
using LuaParser.Syntax;

namespace LuaParser
{
    internal class EmptyStatement : Statement
    {
        public override IEnumerable<Unit> Children
        {
            get { return new Unit[0]; }
        }
    }
}