using MetanitPatterns.BehavioralPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns
{
    public static class BehavioralPatternsDemo
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
                    case 's':
                        StrategyPatternExample.Display();
                        break;
                    case 'o':
                        ObserverPatternExample.Display();
                        break;
                    case 'c':
                        CommandPatternExample.Display();
                        break;
                    case 'm':
                        CommandPatternMulti.Display();
                        CommandPatternMacro.Display();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("S - стратегия");
            Console.WriteLine("O - наблюдатель");
            Console.WriteLine("C - команда");
            Console.WriteLine("M - несколько команд");
        }
    }
}
