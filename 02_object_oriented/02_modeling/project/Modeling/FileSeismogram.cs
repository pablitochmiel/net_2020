using System.IO;

namespace Modeling
{
    public class FileSeismogram : ISeismogram
    {
        private readonly TextWriter _textWriter;
        public FileSeismogram(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void Close()
        {
            _textWriter.Close();
        }

        public void Store(double time, double value)
        {
            _textWriter.WriteLine(time.ToString(provider:null)+" "+value.ToString(provider:null));
        }
    }
}