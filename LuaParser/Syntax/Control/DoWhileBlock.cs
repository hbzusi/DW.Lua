using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaParser.Syntax;

namespace LuaParser.Control
{
    class DoWhileBlock : Statement
    {
        public Expression Condition { get; set; }
        public StatementBlock StatementBlock { get; set; }
    }
}
