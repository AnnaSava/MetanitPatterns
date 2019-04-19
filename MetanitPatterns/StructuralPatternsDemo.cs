using MetanitPatterns.StructuralPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns
{
    public static class StructuralPatternsDemo
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
                    case 'd':
                        DecoratorPatternExample.Display();
                        break;
                    case 'a':
                        AdapterPatternExample.Display();
                        break;
                    case 'f':
                        FacadePatternExample.Display();
                        break;
                    case 'c':
                        CompositePatternExample.Display();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("D - декоратор");
            Console.WriteLine("A - адаптер");
            Console.WriteLine("F - фасад");
            Console.WriteLine("C - компоновщик");
        }
    }
}
