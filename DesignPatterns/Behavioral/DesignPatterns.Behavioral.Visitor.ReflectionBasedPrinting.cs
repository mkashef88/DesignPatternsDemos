using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns.Behavioral.Visitor.ReflectionBasedPrinting
{
    using DicType = Dictionary<Type, Action<Expression, StringBuilder>>;

    public abstract class Expression
    {
        
    }
    public class DoubleExpression : Expression
    {
        public double Value;
        public DoubleExpression(double value)
        {
            this.Value = value;
        }
        
    }

    public class AdditionExpression : Expression
    {
        public Expression Left, Right;
        public AdditionExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }
        
    }

    public static class ExpressionPrinter
    {
        private static DicType actions = new DicType
        {
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.Value);
            },
            [typeof(AdditionExpression)] = (e, sb) =>
            {
                var ae = (AdditionExpression)e;
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append("+");
                Print(ae.Right,sb);
                sb.Append(")");
            }
        };
        public static void Print(Expression e, StringBuilder sb)
        {
            actions[e.GetType()](e, sb);
    }
        public static void Print2(Expression e, StringBuilder sb)
        {
            if (e is DoubleExpression de)
            {
                sb.Append(de.Value);
            }
            else
            if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append("+");
                Print(ae.Right, sb);
                sb.Append(")");
            }
            // breaks open-closed principle
            // will work incorrectly on missing case
        }
    }

   
    class ReflectionBasedPrinting
    {
        //public static void Main()
        //{
        //    var e = new AdditionExpression(
        //      left: new DoubleExpression(1),
        //      right: new AdditionExpression(
        //        left: new DoubleExpression(2),
        //        right: new DoubleExpression(3)));
        //    var sb = new StringBuilder();
        //    ExpressionPrinter.Print2(e, sb);
        //    WriteLine(sb);
        //}
    }
}
