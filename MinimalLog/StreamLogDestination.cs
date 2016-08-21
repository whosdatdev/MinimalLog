using System;
using System.IO;
using System.Text;

namespace MinimalLog
{
    public class StreamLogDestination : ILogDestination
    {
        private readonly bool _autoflush;
        private readonly Stream _destination;
        private readonly Encoding _encoding = Encoding.Unicode;

        public StreamLogDestination(Stream destination, bool autoflush = false)
        {
            if (!destination.CanWrite) throw new ArgumentException("Stream must be writeable", nameof(destination));
            _destination = destination;
            _autoflush = autoflush;
        }

        public StreamLogDestination(Stream destination, Encoding encoding, bool autoflush = false) : this(destination, autoflush)
        {
            _encoding = encoding;
        }

        public void Write(string preText, string text, Severity severity)
        {
            var buffer = _encoding.GetBytes(preText + text);
            _destination.Write(buffer, 0, buffer.Length);
            if (_autoflush)
                _destination.Flush();
        }
    }
}