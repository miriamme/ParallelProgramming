//http://www.csharpstudy.com/Threads/async-delegate.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class AsynchronousDelegateSample
    {
        public void Main()
        {
            Func<int, int, int> work = GetArea;
            IAsyncResult asyncRes = work.BeginInvoke(10, 20, null, null);

            Console.WriteLine("Do something in Main thread");

            int result = work.EndInvoke(asyncRes);

            Console.WriteLine($"Result={result}");
        }

        private int GetArea(int height, int width)
        {
            int area = height * width;
            return area;
        }
    }
}
