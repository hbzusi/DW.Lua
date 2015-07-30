using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LuaParser.Syntax
{
    struct Value { }

    class Type { }

    class Variable
    {
        public string Name;
    }

    public abstract class Statement : Unit
    {
    }

    public abstract class Unit
    {
        public abstract IEnumerable<Unit> Children { get; }
    }

    class Assignment : Statement
    {
        public IList<Variable> Variables { get; set; }
        public IList<Expression> Expressions { get; set; }
        public bool Local { get; set; }

        public override IEnumerable<Unit> Children
        {
            get { return (Expressions ?? new Expression[0]); }
        }
    }

    public class StatementBlock : Statement
    {
        public StatementBlock()
        {
            Statements = new List<Statement>();
        }

        public IList<Statement> Statements { get; private set; }

        public override IEnumerable<Unit> Children
        {
            get { return Statements; }
        }
    }

    public abstract class Expression : Unit
    {
    }

    class FunctionCallExpression : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FunctionName { get; set; }
        public IList<Expression> Parameters { get; set; }
    }

    class FunctionCallStatement : Statement {
        public override IEnumerable<Unit> Children
        {
            get { return new Unit[0]; }
        }
    }

    class BinaryOperation : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }
    }

    class UnaryOperation : Expression
    {
        public override IEnumerable<Unit> Children
        {
            get { throw new System.NotImplementedException(); }
        }
    }

    class FunctionDeclaration : StatementBlock
    {
        
    }

    abstract class ConstValue : Expression { public abstract Value Value { get; } }
}