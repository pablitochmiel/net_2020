using System;
using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            int[] data = {1, 2, 3, 4, 5, 6, 7, 8, 9};

            var demo = new Demo(data);

            Console.WriteLine($"Sum: {demo.Sum()}");
        }
    }
}