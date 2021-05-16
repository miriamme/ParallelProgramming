//http://www.csharpstudy.com/Threads/thread.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ThreadSample2
    {
        public void Main()
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            Thread t2 = new Thread(Run);
            t2.Start();

            Thread t3 = new Thread(delegate () {
                Run();
            });
            t3.Start();

            Thread t4 = new Thread(() => {
                Run();
            });
            t4.Start();

            Thread t5 = new Thread(() => Run());
            t5.Start();

            new Thread(() => Run()).Start();
        }

        void Run()
        {
            Console.WriteLine("Run");
        }
    }
}
