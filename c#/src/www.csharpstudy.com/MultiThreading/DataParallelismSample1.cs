//http://www.csharpstudy.com/Threads/parallel.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class DataParallelismSample1
    {
        public void Main()
        {
            int to = 10;

            for (int i = 0; i < to; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }

            Console.Read();

            Parallel.For(0, to, (i) => {
                Console.WriteLine($"\t{Thread.CurrentThread.ManagedThreadId}: {i}");
            });
        }
    }
}
