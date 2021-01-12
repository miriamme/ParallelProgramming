//http://www.csharpstudy.com/Threads/thread.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ThreadSample1
    {
        public void DoTest()
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            Run();
        }

        private void Run()
        {
            Console.WriteLine("Thread#{0}: Begin", Thread.CurrentThread.ManagedThreadId);
            // Do Something
            Thread.Sleep(3000);
            Console.WriteLine("Thread#{0}: End", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
