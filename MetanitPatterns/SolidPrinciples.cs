using MetanitPatterns.SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns
{
    public static class SolidPrinciples
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
                        SingleResponsibility_Report.Display();
                        Console.WriteLine("--------");
                        SingleResponsibility_MobileStore.Display();
                        break;
                    case 'o':
                        OpenClosed.Display();
                        Console.WriteLine("--------");
                        OpenClosed_TemplateMethod.Display();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("S - Принцип единственной обязанности");
            Console.WriteLine("O - Принцип открытости/закрытости");
        }
    }
}
