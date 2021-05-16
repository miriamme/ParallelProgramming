using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class TaskGenericSample2
    {
        private CancellationTokenSource cancelTokenSource;
        public void Main()
        {
            Run();
        }

        private void LongCalcWithStateAsync(object state)
        {
            throw new NotImplementedException();
        }

        private async void Run()
        {
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var task1 = Task.Factory.StartNew<object>(LongCalcAsync, token);
            dynamic res = await task1;
            if (res != null)
                Console.WriteLine($"Sum={res.Sum}");
            else
                Console.WriteLine("Cancelled");
        }

        public void Cancel()
        {
            cancelTokenSource.Cancel();
        }

        private object LongCalcAsync()
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                if (cancelTokenSource.IsCancellationRequested)
                    return null;

                sum += i;
                Thread.Sleep(1000);
            }
            return new { Sum = sum };
        }
    }
}
