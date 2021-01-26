using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace NamedPipeServer
{
    class Program
    {
        private const int THREAD_NUMBER = 1;

        static void Main(string[] args)
        {
            int i;
            Thread[] servers = new Thread[THREAD_NUMBER];

            Console.WriteLine("\n*** Named pipe server stream with impersonation example ***\n");
            Console.WriteLine("Waiting for client connect...\n");
            for (i = 0; i < THREAD_NUMBER; i++)
            {
                servers[i] = new Thread(ServerThread);
                servers[i].Start();
            }
            Thread.Sleep(250);
            while (i > 0)
            {
                for (int j = 0; j < THREAD_NUMBER; j++)
                {
                    if (servers[j] != null)
                    {
                        if (servers[j].Join(250))
                        {
                            Console.WriteLine("Server thread[{0}] finished.", servers[j].ManagedThreadId);
                            servers[j] = null;
                            i--;    // decrement the thread watch count
                        }
                    }
                }
            }
            Console.WriteLine("\nServer threads exhausted, exiting.");
        }

        private static void ServerThread(object data)
        {
            NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, THREAD_NUMBER);

            int threadId = Thread.CurrentThread.ManagedThreadId;

            // Wait for a client to connect
            pipeServer.WaitForConnection();

            Console.WriteLine("Client connected on thread[{0}].", threadId);
            try
            {
                // Read the request from the client. Once the client has
                // written to the pipe its security token will be available.

                StreamString ss = new StreamString(pipeServer);

                // Verify our identity to the connected client using a
                // string that the client anticipates.

                ss.WriteString("I am the one true server!");
                string filename = ss.ReadString();

                // Read in the contents of the file while impersonating the client.
                ReadFileToStream fileReader = new ReadFileToStream(ss, filename);

                // Display the name of the user we are impersonating.
                Console.WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                    filename, threadId, pipeServer.GetImpersonationUserName());
                pipeServer.RunAsClient(fileReader.Start);
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
            pipeServer.Close();
        }
    }
}
