using System;
using Modeling;
using Xunit;

namespace Test
{
    public class SinSourceTest
    {
        [Theory]
        [InlineData(-1.00, +0.0)]
        [InlineData(-0.75, +1.0)]
        [InlineData(-0.50, +0.0)]
        [InlineData(-0.25, -1.0)]
        [InlineData(+0.00, +0.0)]
        [InlineData(+0.25, +1.0)]
        [InlineData(+0.50, +0.0)]
        [InlineData(+0.75, -1.0)]
        [InlineData(+1.00, +0.0)]
        public void ItIsASineWave(double time, double value)
        {
            var source = new SinSource(1.0, 0.0, 1.0);
            Assert.Equal(value, source.Sample(time), 2);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.3)]
        public void CanChangeAmplitude(double amplitude)
        {
            var source = new SinSource(1.0, 0.0, amplitude);
            Assert.Equal(amplitude, source.Sample(0.25), 2);
        }

        [Theory]
        [InlineData(0.0, 0.25)]
        [InlineData(2 * Math.PI, 0.25)]
        [InlineData(-2 * Math.PI, 0.25)]
        [InlineData(Math.PI, 0.75)]
        [InlineData(-Math.PI, -0.25)]
        public void CanChangePhase(double phase, double time)
        {
            var source = new SinSource(1.0, phase, 1.0);
            Assert.Equal(1.0, source.Sample(time), 2);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CanChangeFrequency(double frequency)
        {
            var source = new SinSource(frequency, 0.0, 1.0);
            Assert.Equal(1.0, source.Sample(1.0 / frequency / 4.0), 2);
        }

        [Fact]
        public void CanGetConfiguration()
        {
            const double frequency = 1.0;
            const double phase = 2.0;
            const double amplitude = 3.0;

            var source = new SinSource(frequency, phase, amplitude);

            Assert.Equal(frequency, source.Frequency);
            Assert.Equal(phase, source.Phase);
            Assert.Equal(amplitude, source.Amplitude);
        }
    }
}