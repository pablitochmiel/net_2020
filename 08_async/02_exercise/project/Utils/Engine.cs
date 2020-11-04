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

        public Engine(ICommandFactory? factoryMockObject)
        {
            _commands=new List<Command>();
            _commandFactory = factoryMockObject ?? throw new NullReferenceException();
            _tasks=new List<Task<string>>();
            _taskCommands=new Dictionary<Task<string>, Command>();
        }

        public async Task RunAsync()
        {
            var inputCommand = _commandFactory.Create("input");
            Console.WriteLine("[+] " + inputCommand.Name);
            var task = inputCommand.RunAsync(_commandFactory.CancellationTokenSource.Token);
            
            _tasks.Add(task);
            _commands.Add(inputCommand);
            _taskCommands.Add(task,inputCommand);
            
            while (_tasks.Count > 0)
            {
                task = await Task.WhenAny(_tasks);
                try
                {
                    string result = await task;
                    inputCommand = _taskCommands[task];
                    Console.WriteLine("[-] " + inputCommand.Name);

                    if (!string.IsNullOrEmpty(result)) Console.WriteLine("[=] " + result);
                    
                    var commands = inputCommand.Continuations(result, _commandFactory);
                    foreach (var command in commands)
                    {
                        Console.WriteLine("[+] " + command.Name);
                        Task<string> runTask = command.RunAsync(_commandFactory.CancellationTokenSource.Token);
                        _tasks.Add(runTask);
                        _commands.Add(command);
                        _taskCommands.Add(runTask,command);
                    }

                    _tasks.Remove(task);
                    _commands.Remove(_taskCommands[task]);
                    _taskCommands.Remove(task);
                }
                catch (TaskCanceledException)
                {
                    var command = _taskCommands[task];
                    Console.WriteLine("[-] "+inputCommand.Name);
                    Console.WriteLine("[X] "+inputCommand.Name);
                    if (_commands.Contains(command)) _commands.Remove(command);
                    _tasks.Remove(task);
                    _taskCommands.Remove(task);
                }
            }
        }
    }
}