using System;
using System.Net.Http;
using System.Threading;

namespace Utils
{
    public class CommandFactory:ICommandFactory
    {
        public CommandFactory(CancellationTokenSource cancellationTokenSource)
        {
            CancellationTokenSource = cancellationTokenSource;
        }

        public CancellationTokenSource CancellationTokenSource { get;  }

        public Command Create(params string[] arguments)
        {
            switch (arguments[0])
            {
                case "print":
                    switch (arguments.Length)
                    {
                        case 1:
                            return new DelayedPrintCommand("Hello!", 5000, new Time());
                        case 2:
                            return new DelayedPrintCommand(arguments[1],5000,new Time());
                        default:
                            return new DelayedPrintCommand(arguments[1],int.Parse(arguments[2],provider:null),new Time());
                    }
                case "exit":
                    CancellationTokenSource.Cancel();
                    return new NullCommand();
                case "input":
                    return new InputCommand();               
                case "size":
                    if(arguments.Length==1)
                        return new SizeCommand(new Uri("https://google.com"),new Client(new HttpClient()) );
                    return new SizeCommand(new Uri(arguments[1]),new Client(new HttpClient()) );
                default:
                    return new NullCommand();
            }
        }
    }
}