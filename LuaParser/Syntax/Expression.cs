using System.Collections;
using System.Collections.Generic;

namespace LuaParser.Syntax
{
    struct Value { }

    class Type { }

    class Variable
    {
        public string Name;
    }

    public class Statement
    {
    }

    class Assignment : Statement
    {
        public IList<Variable> Variables { get; set; }
        public IList<Expression> Expressions { get; set; }
        public bool Local { get; set; }
    }

    public class Block : Statement
    {
        public Block()
        {
            Statements = new List<Statement>();
        }

        public IList<Statement> Statements { get; private set; }
    }

    class Expression
    {
    }

    class FunctionCallExpression : Expression
    {
        
    }

    class FunctionCallStatement : Statement { }

    class BinaryOperation : Expression
    {
    }

    class UnaryOperation : Expression
    {
    }

    class FunctionDeclaration : Block
    {
        
    }

    abstract class ConstValue : Expression { public abstract Value Value { get; } }
}