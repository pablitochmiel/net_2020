namespace Modeling
{
    public class Simulation
    {
        private readonly ISeismogram _seismogram;
        private readonly ISource _source;
        public Simulation(ISource source, ISeismogram seismogram)
        {
            _seismogram = seismogram;
            _source = source;
        }

        public void Execute(double d, double d1, double d2)
        {
            if (d < d2)
            {
                for (var i = d; i <= d2; i += d1)
                {
                    _seismogram.Store(i, _source.Sample(i));
                }
            }
            for (var i = d; i >= d2; i += d1)
            {
                _seismogram.Store(i, _source.Sample(i));
            }

            //_seismogram.Store(d1,_source.Sample(d1));
            //_seismogram.Store(d2,_source.Sample(d2));
        }
    }
}