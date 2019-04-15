using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.BehavioralPatterns
{
    static class StrategyPattern
    {
        public interface IStrategy
        {
            void Algorithm();
        }

        public class ConcreteStrategy1 : IStrategy
        {
            public void Algorithm()
            { }
        }

        public class ConcreteStrategy2 : IStrategy
        {
            public void Algorithm()
            { }
        }

        public class Context
        {
            public IStrategy ContextStrategy { get; set; }

            public Context(IStrategy _strategy)
            {
                ContextStrategy = _strategy;
            }

            public void ExecuteAlgorithm()
            {
                ContextStrategy.Algorithm();
            }
        }
    }
}
