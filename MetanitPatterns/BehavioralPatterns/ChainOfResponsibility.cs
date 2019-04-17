using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.BehavioralPatterns
{
    static class ChainOfResponsibility
    {
        public static void Display()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            h1.HandleRequest(2);
        }

        abstract class Handler
        {
            public Handler Successor { get; set; }
            public abstract void HandleRequest(int condition);
        }

        class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int condition)
            {
                if (condition == 1)
                {
                    // обработка;
                }
                else if (Successor != null)
                {
                    Successor.HandleRequest(condition);
                }
            }
        }

        class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int condition)
            {
                if (condition == 2)
                {
                    // обработка;
                }
                else if (Successor != null)
                {
                    Successor.HandleRequest(condition);
                }
            }
        }
    }
}
