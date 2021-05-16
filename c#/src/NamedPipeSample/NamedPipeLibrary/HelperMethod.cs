using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipeLibrary
{
    public class HelperMethod
    {
        public static void WriteLog(string format, bool printTimeStamp, params object[] parameterArray)
        {
            string message;
            if (parameterArray.Length == 0)
            {
                message = format;
            }
            else
            {
                message = string.Format(format, parameterArray);
            }

            string log;
            if (printTimeStamp)
            {
                log = string.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss"), message);
            }
            else
            {
                log = string.Format("{0}", message);
            }
            Console.WriteLine(log);
        }
    }
}
