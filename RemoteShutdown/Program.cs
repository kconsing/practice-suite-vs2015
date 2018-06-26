using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Diagnostics;
using System.IO;

namespace RemoteShutdown
{
    class Program
    {
        static void Main(string[] args)
        {
            Impersonator imp = new Impersonator();
            imp.Impersonate("stdl", "administrator", "Xreager4");
            Log("Starting Remote Shutdown");
            try
            {
                Shut("ca-04");
            }
            catch(Exception e)
            {
                Log("Error: " + e.Message);
            }
            finally
            {
                //Shut2();
            }

            imp.Undo();
        }

        static void Shut(string pcName)
        {
            Log("Shut1");
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();

            info.WindowStyle = ProcessWindowStyle.Hidden;
            //info.WorkingDirectory = @"C:\Windows\system32\";
            info.FileName = @"shutdown";
            info.Arguments = $@"/f /r /m \\{pcName} /t 00";
            info.UseShellExecute = false;

            Log(info.Arguments);
            p.StartInfo = info;
            
            p.Start();
        }

        static void Shut2()
        {
            Log("Shut2");
            Process.Start("shutdown", @"/f /r /m \\ca-04 /t 00");
        }

        static void Log(string  message)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string programName = "RemoteShutdown";

            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "RemoteShutdown.log"))
            {
                sw.WriteLine($"[{programName}]({time})-> {message} \r\n");
            }
        }
    }
}
