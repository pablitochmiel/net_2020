using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            var window = new Window();

            window.SimulateClicks();
        }
    }
}