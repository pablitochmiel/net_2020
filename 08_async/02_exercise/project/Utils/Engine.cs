using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class Engine
    {
        private readonly ICommandFactory _commandFactory;
        private readonly List<Command> _commands;
        private readonly Dictionary<Task<string>, Command> _taskCommands;
        private readonly List<Task<string>> _tasks;

        public Engine(ICommandFactory factoryMockObject)
        {
            _commands=new List<Command>();
            _commandFactory = factoryMockObject;
            _tasks=new List<Task<string>>();
            _taskCommands=new Dictionary<Task<string>, Command>();
        }

        public async Task RunAsync()
        {
            while (_tasks.Count > 0)
            {
                var task = await Task.WhenAny(_tasks);
                _tasks.Remove(task);
                var result = await task;
                Console.WriteLine(result);
            }
        }
    }
}