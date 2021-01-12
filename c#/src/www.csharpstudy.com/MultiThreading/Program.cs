#define TaskGenericSample2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
#if (ThreadSample1)
            new ThreadSample1().DoTest();
#elif (ThreadSample2)
            new ThreadSample2().Main();
#elif (ThreadSample3)
            new ThreadSample3().Main();
#elif (ThreadSample4)
            new ThreadSample4().Main();
#elif (ThreadPoolSample)
            new ThreadPoolSample().Main();
#elif (AsynchronousDelegateSample)
            new AsynchronousDelegateSample().Main();
#elif (BackgroundWorkerSample)
            new BackgroundWorkerSample().Main();
#elif (TaskSample1)
            new TaskSample1().Main();
#elif (TaskSample2)
            new TaskSample2().Main();
#elif (TaskGenericSample1)
            new TaskGenericSample1().Main();
#elif (TaskGenericSample2)
            TaskGenericSample2 sample2 = new TaskGenericSample2();
            sample2.Main();
            Thread.Sleep(5000);
            sample2.Cancel();

#endif
        }
    }
}
