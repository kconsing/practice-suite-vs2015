using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

[assembly: AssemblyVersion("1.0.*")]

namespace VersionNumberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly thisAssem = typeof(Program).Assembly;
            AssemblyName thisAssemName = thisAssem.GetName();

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            Console.WriteLine("This is version {0} of {1}.", version, thisAssemName.Name);
        }
    }
}
