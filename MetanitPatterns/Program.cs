using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetanitPatterns.CreationalPatterns;

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
                    case 'f':
                        FactoryMethodPatternExample.Run();
                        break;
                    case 'a':
                        AbstractFactoryPatternExample.Run();
                        break;
                }
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для выбора раздела");
            Console.WriteLine("F - фабричный метод");
            Console.WriteLine("A - абстрактрая фабрика");
        }
    }
}
