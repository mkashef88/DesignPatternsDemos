using System.Text;
using static System.Console;

namespace DesignPatterns.Behavioral
{
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double Value;
        public DoubleExpression(double value)
        {
            this.Value = value;
        }
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class AdditionExpression : Expression
    {
        public Expression Left;
        public Expression Right;

        public AdditionExpression(Expression left,Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            sb.Append(de.Value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.Left.Accept(this);
            sb.Append("+");
            ae.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString() => sb.ToString();
      
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;
        public void Visit(DoubleExpression de)
        {
            Result = de.Value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.Left.Accept(this);
            var a = Result;
            ae.Right.Accept(this);
            var b = Result;
            Result = a + b;
        }
    }
    class DesignPatterns
    {
        //public static void Main()
        //{
        //    var e = new AdditionExpression(
        //      left: new DoubleExpression(1),
        //      right: new AdditionExpression(
        //        left: new DoubleExpression(2),
        //        right: new DoubleExpression(3)));
        //    var ep = new ExpressionPrinter();
        //    ep.Visit(e);
        //    WriteLine(ep.ToString());

        //    var calc = new ExpressionCalculator();
        //    calc.Visit(e);
        //    WriteLine($"{ep} = {calc.Result}");
        //}
    }
}
