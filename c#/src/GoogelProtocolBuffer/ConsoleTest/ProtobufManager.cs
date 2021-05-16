using ProtoBuf;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class ProtobufManager
    {
        private const string PROTO_EXTENSION = "proto";

        public void FileWrite<T>(string directoryName = null) where T : class
        {
            if (string.IsNullOrEmpty(directoryName))
                directoryName = "./proto";

            DirectoryInfo dir = new DirectoryInfo(directoryName);
            if (!dir.Exists)
                dir.Create();

            string fileName = $"{typeof(T).Name}.{PROTO_EXTENSION}";
            string filePath = Path.Combine(directoryName, fileName);
            string protoFileData = Serializer.GetProto<T>();

            using(StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(protoFileData);
            }
        }
    }
}
