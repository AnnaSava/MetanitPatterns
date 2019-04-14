using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitPatterns.CreationalPatterns
{
    static class SingletonStaticFields
    {
        public static void Display()
        {
            Console.WriteLine($"Display {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton.text);
        }

        public class Singleton
        {
            private static readonly Singleton instance = new Singleton();
            public static string text = "hello";
            public string Date { get; private set; }

            private Singleton()
            {
                Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
                Date = System.DateTime.Now.TimeOfDay.ToString();
            }

            public static Singleton GetInstance()
            {
                Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
                Thread.Sleep(500);
                return instance;
            }
        }
    }

    static class SingletonNestedClass
    {
        public static void Display()
        {
            Console.WriteLine($"Display {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton.text);

            Singleton singleton1 = Singleton.GetInstance();
            Console.WriteLine(singleton1.Date);
        }

        public class Singleton
        {
            public string Date { get; private set; }
            public static string text = "hello";
            private Singleton()
            {
                Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
                Date = DateTime.Now.TimeOfDay.ToString();
            }

            public static Singleton GetInstance()
            {
                Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
                return Nested.instance;
            }

            private class Nested
            {
                internal static readonly Singleton instance = new Singleton();
            }
        }
    }


    static class SingletonNestedLazy
    {
        public static void Display()
        {
            Console.WriteLine($"Display {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton.text);

            Singleton singleton1 = Singleton.GetInstance();
            Console.WriteLine(singleton1.Date);
        }

        public class Singleton
        {
            public string Date { get; private set; }
            public static string text = "hello";
            private Singleton()
            {
                Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
                Date = DateTime.Now.TimeOfDay.ToString();
            }

            public static Singleton GetInstance()
            {
                Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
                Thread.Sleep(500);
                return Nested.instance;
            }

            private class Nested
            {
                static Nested() { }
                internal static readonly Singleton instance = new Singleton();
            }
        }
    }
}
