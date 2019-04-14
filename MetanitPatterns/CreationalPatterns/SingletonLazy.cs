using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitPatterns.CreationalPatterns
{
    static class SingletonLazy
    {
        public static void Display()
        {
            Console.WriteLine(Singleton.GetInstance().Name);
        }

        public class Singleton
        {
            private static readonly Lazy<Singleton> lazy =
                new Lazy<Singleton>(() => new Singleton());

            public string Name { get; private set; }

            private Singleton()
            {
                Name = System.Guid.NewGuid().ToString();
            }

            public static Singleton GetInstance()
            {
                return lazy.Value;
            }
        }
    }
}
