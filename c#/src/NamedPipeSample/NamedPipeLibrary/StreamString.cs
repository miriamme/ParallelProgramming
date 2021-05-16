using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipeLibrary
{
    public class StreamString
    {
        private Stream stream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream stream)
        {
            this.stream = stream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;
            len = stream.ReadByte() * 256;
            len += stream.ReadByte();
            byte[] inBuffer = new byte[len];
            stream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            stream.WriteByte((byte)(len / 256));
            stream.WriteByte((byte)(len & 256));
            stream.Write(outBuffer, 0, len);
            stream.Flush();

            return outBuffer.Length + 2;
        }
    }
}
