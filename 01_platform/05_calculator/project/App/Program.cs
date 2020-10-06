using System;
using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var c = new Calculator(double.Parse(args[0], null), double.Parse(args[2], null));
            switch (args[1])
            {
                case "add":
                    Console.WriteLine($"{args[0]} add {args[2]} = {c.Add()}");
                    break;
                case "sub":
                    Console.WriteLine($"{args[0]} sub {args[2]} = {c.Sub()}");
                    break;
                case "mul":
                    Console.WriteLine($"{args[0]} mul {args[2]} = {c.Mul()}");
                    break;
                case "div":
                    Console.WriteLine($"{args[0]} div {args[2]} = {c.Div()}");
                    break;
            }
        }
    }
}