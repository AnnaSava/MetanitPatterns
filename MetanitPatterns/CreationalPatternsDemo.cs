using MetanitPatterns.CreationalPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns
{
  public static  class CreationalPatternsDemo
    {
        public static void Run()
        {
            char key;

            while (true)
            {
                printMenu();

                key = Console.ReadKey().KeyChar;

                Console.WriteLine();
                switch (key)
                {
                    case 'f':
                        FactoryMethodPatternExample.Display();
                        break;
                    case 'a':
                        AbstractFactoryPatternExample.Display();
                        break;
                    case 's':
                        SingletonPatternExample.Display();
                        SingletonLock.Display();
                        SingletonThreads.Display();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("F - фабричный метод");
            Console.WriteLine("A - абстрактрая фабрика");
            Console.WriteLine("S - синглтон");
        }
    }
}
