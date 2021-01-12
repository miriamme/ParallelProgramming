//http://www.csharpstudy.com/Threads/task.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class TaskSample1
    {
        public void Main()
        {
            Task.Factory.StartNew(new Action<object>(Run), null);
            Task.Factory.StartNew(new Action<object>(Run), "1st");
            Task.Factory.StartNew(Run, "2nd");

            Console.Read();
        }

        private void Run(object data)
        {
            Console.WriteLine(data == null ? "NULL" : data);
        }
    }
}
