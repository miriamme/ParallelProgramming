using NamedPipeLibrary;

using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipeSimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperMethod.WriteLog("PRESS ANY KEY TO START SERVER", true);

            Console.ReadKey(true);

            string message = null;

            HelperMethod.WriteLog("WAIT FOR CONNECTION...", true);

            while (true)
            {
                Run(message);
            }
        }

        private static void Run(string message)
        {
            using NamedPipeServerStream stream = new NamedPipeServerStream(ConstantConfig.SIMPLE_PIPE_NAME, PipeDirection.In);
            stream.WaitForConnection();

            StreamReader reader = new StreamReader(stream);
            message = reader.ReadToEnd();

            HelperMethod.WriteLog($"received::{message}", false);
        }

    }
}
