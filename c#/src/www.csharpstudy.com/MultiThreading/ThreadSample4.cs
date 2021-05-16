//http://www.csharpstudy.com/Threads/thread2.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ThreadSample4
    {
        public void Main()
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(10.00);

            Thread t3 = new Thread(() => Sum(10, 20, 30));
            t3.Start();
        }

        void Run()
        {
            Console.WriteLine("Run");
        }

        void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine($"r = {r}, area = {area}");
        }

        void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            Console.WriteLine(sum);
        }
    }
}
