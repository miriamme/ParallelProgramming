//http://www.csharpstudy.com/Threads/backgroundworker.aspx

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class BackgroundWorkerSample
    {
        private BackgroundWorker worker;

        public void Main()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Long running task");
        }
    }
}
