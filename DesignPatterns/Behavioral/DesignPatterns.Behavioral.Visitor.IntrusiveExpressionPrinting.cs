using System.Text;
using static System.Console;

namespace DesignPatterns.Behavioral.Visitor.IntrusiveExpressionPrinting
{
    public abstract class Expression
    {
        public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        private readonly double value;
        public DoubleExpression(double value)
        {
            this.value = value;
        }
        public override void Print(StringBuilder sb)
        {
            sb.Append(value);
        }
    }

    public class AdditionExpression : Expression
    {
        private Expression left, right;
        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            left.Print(sb);
            sb.Append("+");
            right.Print(sb);
            sb.Append(")");
        }
    }
    class IntrusiveExpressionPrinting
    {
        //public static void Main(string[] args)
        //{
        //    var e = new AdditionExpression(
        //left: new DoubleExpression(1),
        //right: new AdditionExpression(
        //  left: new DoubleExpression(2),
        //  right: new DoubleExpression(3)));
        //    var sb = new StringBuilder();
        //    e.Print(sb);
        //    WriteLine(sb);
        //}
    }
}
