using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.BehavioralPatterns
{
    static class InterpreterPattern
    {
        public static void Display()
        {
            Context context = new Context();

            var expression = new NonterminalExpression();
            expression.Interpret(context);
        }

        class Context
        {
        }

        abstract class AbstractExpression
        {
            public abstract void Interpret(Context context);
        }

        class TerminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
            }
        }

        class NonterminalExpression : AbstractExpression
        {
            AbstractExpression expression1;
            AbstractExpression expression2;
            public override void Interpret(Context context)
            {

            }
        }
    }
}
