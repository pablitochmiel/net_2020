using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main(string[] args)
        {
            var users = from arg in args select new User {Name = arg};

            users.ToList().ForEach(u => Console.WriteLine(u.Name));
        }
    }
}