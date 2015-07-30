using System.Collections.Generic;

namespace LuaParser.Syntax
{
    class FunctionCallExpression : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FunctionName { get; set; }
        public IList<Expression> Parameters { get; set; }
    }
}