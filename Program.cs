using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace testingapplication
{
    class Program
    {
        //PINVOKE
        [DllImport("kernel32.dll")]
        static extern uint WinExec(string lpCmdLine, uint uCmdShow);
        static void Main(string[] args)
        {
            //Console.WriteLine(Environment.CurrentDirectory);
            string cutregpath = @"\\Pharos90r2\CustomBin\temp\Crocodile.exe";
            WinExec(cutregpath, 5);
            //WinExec("whoami", 5);
            //BackgroundThread.Run();

            //Console.WriteLine("Press any key to continue. . . This will keep SayHello.exe alive.");
            Console.ReadKey();          
        }
    }
}
