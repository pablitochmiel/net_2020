using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Double;

namespace Modeling
{
    public class FileSource : ISource
    {
        //private string[] Lines;
        private readonly List<Line> _lines=new List<Line>();
        public FileSource(TextReader? textReader)
        {
            //Lines = System.IO.File.ReadAllLines(textReader.read);
            if (textReader is null)
            {
                throw new ArgumentNullException(nameof(textReader));
            }
            
            while (true)
            {
                var temp = textReader.ReadLine();
                if (temp == null)
                {
                    break;
                }

                if(temp.Split().GetLength(0)!=2)
                {
                    throw new InvalidFileException();
                }
                _lines.Add(new Line(Parse(temp.Split()[0],null),Parse(temp.Split()[1],null)));

            }
        }
        
        public double Sample(double time)
        {
            switch (_lines.Count)
            {
                // if (time<
                //return Parse(Lines.ElementAt(0).Amplitude,provider:null);
                case 0:
                    return 0;
                case 1:
                    return _lines.ElementAt(0).Amplitude;
            }

            if (time < _lines.ElementAt(0).Time)
            {
                return _lines.ElementAt(0).Amplitude;
            }
            for (var i = 0; i < _lines.Count; i++)
            {
                if (Math.Abs(time - _lines.ElementAt(i).Time)<0.01)
                {
                    return _lines.ElementAt(i).Amplitude;
                }
                if (time < _lines.ElementAt(i).Time)
                {
                    return _lines.ElementAt(i - 1).Amplitude +
                           (_lines.ElementAt(i).Amplitude - _lines.ElementAt(i - 1).Amplitude) /
                           (_lines.ElementAt(i).Time - _lines.ElementAt(i - 1).Time) *
                           (time - _lines.ElementAt(i - 1).Time);
                }
            }
            return _lines.ElementAt(_lines.Count-1).Amplitude;
        }
    }

    internal class Line
    {
        public double Time { get; }
        public double Amplitude { get; }

        public Line(double time, double amplitude)
        {
            Time = time;
            Amplitude = amplitude;
        }
    }
}