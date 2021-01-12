//http://www.csharpstudy.com/Threads/task.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class TaskSample2
    {
        public void Main()
        {
            Task t1 = new Task(Run);
            Task t2 = new Task(() => {
                Console.WriteLine("Long query");
            });

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();
        }

        private void Run()
        {
            Console.WriteLine("Long running method");
        }
    }
}
