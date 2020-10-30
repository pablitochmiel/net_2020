using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            Demo();
            ContainerDemo();
        }

        private static void Demo()
        {
            var infos = new IInfo?[] {new Hello(), new World()};

            Write(infos);
        }

        private static void ContainerDemo()
        {
            var container = new Container();

            container.Map<IInfo, Hello>("A");
            container.Map<IInfo, World>("B");

            var infos = new[] {container.Create<IInfo>("A"), container.Create<IInfo>("B")};

            Write(infos);
        }

        private static void Write(IEnumerable<IInfo?> infos)
        {
            foreach (var info in infos)
            {
                Console.WriteLine(info?.Text);
            }
        }

        private interface IInfo
        {
            string Text { get; }
        }

        private class Hello : IInfo
        {
            public string Text { get; } = "Hello";
        }

        private class World : IInfo
        {
            public string Text { get; } = "World";
        }
    }
}