using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Modeling;

namespace Runner
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            ForwardModeling();
            ReversalModeling();
        }

        private static void ForwardModeling()
        {
            var source = new SinSource(1.0, 0.0, 1.0);
            var seismogram = new FileSeismogram(new StreamWriter("forward.txt"));

            var simulation = new Simulation(source, seismogram);
            simulation.Execute(0.0, 0.01, 1.0);

            seismogram.Close();

            Console.WriteLine("Forward modeling finished!");
        }

        private static void ReversalModeling()
        {
            var source = new FileSource(new StreamReader("forward.txt"));
            var seismogram = new FileSeismogram(new StreamWriter("backward.txt"));

            var simulation = new Simulation(source, seismogram);
            simulation.Execute(1.0, -0.01, 0.0);

            seismogram.Close();

            Console.WriteLine("Reversal modeling finished!");
        }
    }
}