using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloseTVSponsoredSession
{
    class Program
    {
        [DllImportAttribute("User32.dll")]
        private static extern int FindWindow(String ClassName, String WindowName);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static System.Threading.Timer _t;

        static void Main(string[] args)
        {
            // Hide console window
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            // Start timer that checks if the Minecraft window is in the front
            _t = new System.Threading.Timer(TimerCallback, null, 0, 5000);

            // Keep Alive
            Console.ReadLine();
        }

        static void TimerCallback(Object o)
        {
            Console.WriteLine("Checking. . .");
            int hWnd2 = FindWindow(null, "Sponsored Session");
            if(hWnd2 > 0)
            {
                Console.WriteLine("Window found! Giving focus!");
                SetForegroundWindow((IntPtr)hWnd2);
                Console.WriteLine("Sending {ENTER}.");
                SendKeys.SendWait("{ENTER}");
            }
        }
    }
}
