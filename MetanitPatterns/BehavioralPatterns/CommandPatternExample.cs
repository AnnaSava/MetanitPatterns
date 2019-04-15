using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.BehavioralPatterns
{
    static class CommandPatternExample
    {
        public static void Display()
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Microwave microwave = new Microwave();
            // 5000 - время нагрева пищи
            pult.SetCommand(new MicrowaveCommand(microwave, 2000));
            pult.PressButton();
        }

        interface ICommand
        {
            void Execute();
            void Undo();
        }

        // Receiver - Получатель
        class TV
        {
            public void On()
            {
                Console.WriteLine("Телевизор включен!");
            }

            public void Off()
            {
                Console.WriteLine("Телевизор выключен...");
            }
        }

        class TVOnCommand : ICommand
        {
            TV tv;
            public TVOnCommand(TV tvSet)
            {
                tv = tvSet;
            }
            public void Execute()
            {
                tv.On();
            }
            public void Undo()
            {
                tv.Off();
            }
        }

        class NoCommand : ICommand
        {
            public void Execute()
            {
            }
            public void Undo()
            {
            }
        }

        // Invoker - инициатор
        class Pult
        {
            ICommand command;

            public Pult()
            {
                command = new NoCommand();
            }

            public void SetCommand(ICommand com)
            {
                command = com;
            }

            public void PressButton()
            {
                command.Execute();
            }
            public void PressUndo()
            {
                command.Undo();
            }
        }

        class Microwave
        {
            public void StartCooking(int time)
            {
                Console.WriteLine("Подогреваем еду");
                // имитация работы с помощью асинхронного метода Task.Delay
                Task.Delay(time).GetAwaiter().GetResult();
            }

            public void StopCooking()
            {
                Console.WriteLine("Еда подогрета!");
            }
        }
        class MicrowaveCommand : ICommand
        {
            Microwave microwave;
            int time;
            public MicrowaveCommand(Microwave m, int t)
            {
                microwave = m;
                time = t;
            }
            public void Execute()
            {
                microwave.StartCooking(time);
                microwave.StopCooking();
            }

            public void Undo()
            {
                microwave.StopCooking();
            }
        }
    }
}
