using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitPatterns.CreationalPatterns
{
    public static class SingletonThreads
    {
        public static void Display()
        {
            (new Thread(() =>
            {
                Singleton singleton1 = Singleton.GetInstance();
                Console.WriteLine(singleton1.Date);
            })).Start();

            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine(singleton2.Date);
        }

        public class Singleton
        {
            private static readonly Singleton instance = new Singleton();

            public string Date { get; private set; }

            private Singleton()
            {
                Date = System.DateTime.Now.TimeOfDay.ToString();
            }

            public static Singleton GetInstance()
            {
                return instance;
            }
        }
    }
}
