//http://www.csharpstudy.com/Threads/taskOfT.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class TaskGenericSample1
    {
        public void Main()
        {
            Task<int> task = Task.Factory.StartNew<int>(() => CalcSize("Hello World"));

            //메인쓰레드에서 다른 작업 진행
            Thread.Sleep(1000);

            //쓰레드 결과 리턴. 쓰레드가 계속 실행중이면
            //이곳에서 끝날 때까지 대기함
            int result = task.Result;

            Console.WriteLine($"result={result}");
        }

        private int CalcSize(string data)
        {
            string s = data == null ? "" : data;
            //복잡한 계산관정

            return s.Length;
        }
    }
}
