using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            char key;

            while (true)
            {
                printMenu();

                key = Console.ReadKey().KeyChar;

                Console.WriteLine();
                switch (key)
                {
                    case 'c':
                        CreationalPatternsDemo.Run();
                        break;
                    case 'b':
                        BehavioralPatternsDemo.Run();
                        break;
                    case 's':
                        StructuralPatternsDemo.Run();
                        break;
                }
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для выбора раздела");
            Console.WriteLine("C - порождающие паттерны");
            Console.WriteLine("B - поведенческие паттерны");
            Console.WriteLine("S - структурные паттерны");
        }
    }
}
