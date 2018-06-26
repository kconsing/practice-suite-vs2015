using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace RemoteShutdown2
{
    class Program
    {
        static void Main(string[] args)
        {
            Impersonator imp = new Impersonator();
            imp.Impersonate("stdl", "administrator", "Xreager4");
            Log("Hello World.");
            imp.Undo();
            Console.ReadLine();
        }

        static void Log(string message)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string programName = "RemoteShutdown2";

            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "RemoteShutdown2.log"))
            {
                sw.WriteLine($"[{programName}]({time})-> {message} \r\n");
            }
        }
    }
}
