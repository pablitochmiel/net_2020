using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Xunit.Performance.Api;

namespace Bench
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        public static void Main(string[] args)
        {
            using var p = new XunitPerformanceHarness(args);
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                p.Dispose();
                return;
            }
            var entryAssemblyPath = assembly.Location;
            p.RunBenchmarks(entryAssemblyPath);
            
            p.Dispose();
        }
    }
}