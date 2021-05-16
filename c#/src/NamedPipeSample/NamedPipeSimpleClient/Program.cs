using NamedPipeLibrary;

using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace NamedPipeSimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperMethod.WriteLog("PRESS ANY KEY TO CONNECT SERVER", true);

            Console.ReadKey(true);

            while (true)
            {
                if (!Run())
                    break;
            }
        }

        private static bool Run()
        {
            Console.Write("Input Message : ");
            string message = Console.ReadLine();

            if (message.ToUpper() == "Q")
                return false;

            using (NamedPipeClientStream stream = new NamedPipeClientStream(".", ConstantConfig.SIMPLE_PIPE_NAME, PipeDirection.Out, PipeOptions.None))
            {
                if (!stream.IsConnected)
                {
                    stream.Connect(1000);
                    HelperMethod.WriteLog("SERVER CONNECTED...", true);
                }

                StreamWriter writer = new StreamWriter(stream);

                writer.WriteLine(message);

                writer.Flush();
            }
            return true;
        }

    }
}
