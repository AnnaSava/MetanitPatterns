using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.BehavioralPatterns
{
    static class CommandPattern
    {
        abstract class Command
        {
            public abstract void Execute();
            public abstract void Undo();
        }
        // конкретная команда
        class ConcreteCommand : Command
        {
            Receiver receiver;
            public ConcreteCommand(Receiver r)
            {
                receiver = r;
            }
            public override void Execute()
            {
                receiver.Operation();
            }

            public override void Undo()
            { }
        }

        // получатель команды
        class Receiver
        {
            public void Operation()
            { }
        }
        // инициатор команды
        class Invoker
        {
            Command command;
            public void SetCommand(Command c)
            {
                command = c;
            }
            public void Run()
            {
                command.Execute();
            }
            public void Cancel()
            {
                command.Undo();
            }
        }
        class Client
        {
            void Main()
            {
                Invoker invoker = new Invoker();
                Receiver receiver = new Receiver();
                ConcreteCommand command = new ConcreteCommand(receiver);
                invoker.SetCommand(command);
                invoker.Run();
            }
        }
    }
}
