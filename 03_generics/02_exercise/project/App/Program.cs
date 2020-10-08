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
            var collection = new Collection<int> {1, 2, 3};

            Console.WriteLine($"Hello Collections! Count: {collection.Count}");
        }
    }
}