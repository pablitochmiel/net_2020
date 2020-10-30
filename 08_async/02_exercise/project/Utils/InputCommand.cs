using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class InputCommand : Command
    {
        public InputCommand()
        {
            Name = "input";
        }

        public override string Name { get; }
        public override async Task<string> RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            return Console.ReadLine()!;
        }

        public override IEnumerable<Command> Continuations(string? result, ICommandFactory? commandFactory)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            if (commandFactory == null)
            {
                throw new ArgumentNullException(nameof(commandFactory));
            }

            // var res= new Array<Command>();
            // res.Add(commandFactory.Create(result));
            // res.Add(new InputCommand());
            // return Command [] {commandFactory.Create(result),new InputCommand()};
            var a = commandFactory.Create(result.Split());
            var b = commandFactory.Create("input");
            Command[] res={a,b};
            return res;
        }
    }
}