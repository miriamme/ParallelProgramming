//http://www.csharpstudy.com/Threads/thread.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ThreadSample3
    {
        public void Main()
        {
            Helper helper = new Helper();
            Thread t1 = new Thread(helper.Run);
            t1.Start();
        }
    }

    public class Helper
    {
        public void Run()
        {
            Console.WriteLine($"{this.GetType()}.{MethodBase.GetCurrentMethod().Name}");
        }
    }
}
