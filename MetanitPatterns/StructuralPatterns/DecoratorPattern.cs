using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.StructuralPatterns
{
    static class DecoratorPattern
    {
        abstract class Component
        {
            public abstract void Operation();
        }
        class ConcreteComponent : Component
        {
            public override void Operation()
            { }
        }
        abstract class Decorator : Component
        {
            protected Component component;

            public void SetComponent(Component component)
            {
                this.component = component;
            }

            public override void Operation()
            {
                if (component != null)
                    component.Operation();
            }
        }
        class ConcreteDecoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();
            }
        }
        class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();
            }
        }
    }
}
