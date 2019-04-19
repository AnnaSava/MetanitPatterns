using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.StructuralPatterns
{
    static class AdapterPattern
    {
        class Client
        {
            public void Request(Target target)
            {
                target.Request();
            }
        }
        // класс, к которому надо адаптировать другой класс   
        class Target
        {
            public virtual void Request()
            { }
        }

        // Адаптер
        class Adapter : Target
        {
            private Adaptee adaptee = new Adaptee();

            public override void Request()
            {
                adaptee.SpecificRequest();
            }
        }

        // Адаптируемый класс
        class Adaptee
        {
            public void SpecificRequest()
            { }
        }
    }
}
