using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception($"Application should take 1 parameter (not {args.Length})");
            }

            var times = int.Parse(args[0], CultureInfo.InvariantCulture);

            var generator = new Generator(1);

            foreach (var word in generator.Words())
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();

            var fibonacci = new Fibonacci();

            foreach (var number in fibonacci.Numbers().Even().Only(times))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            foreach (var number in fibonacci.Numbers().Odd().Only(times))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
        }
    }
}