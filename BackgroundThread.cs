using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace testingapplication
{
    static class BackgroundThread
    {
        public static void Run()
        {


            System.Threading.Thread t = new System.Threading.Thread(() =>
            {
                //System.Diagnostics.Process.Start("SayHello.exe");

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                /*
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();

                startinfo.FileName = "SayHello.exe";
                startinfo.UseShellExecute = false;

                p.StartInfo = startinfo;
                */
                p.Start();
            });



            t.IsBackground = true;
            t.Start();
        }

    }
}
