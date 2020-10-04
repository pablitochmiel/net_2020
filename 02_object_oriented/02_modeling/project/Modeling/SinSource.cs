using System;

namespace Modeling
{
    public class SinSource :ISource
    {
        public SinSource(in double frequency, in double phase, in double amplitude)
        {
            Frequency = frequency;
            Phase = phase;
            Amplitude = amplitude;
        }

        public double Frequency { get; }
        public double Phase { get; }
        public double Amplitude { get; }

        public double Sample(double time)
        {
            return Amplitude*Math.Sin(2*Math.PI*Frequency*time+Phase);
        }
    }
}