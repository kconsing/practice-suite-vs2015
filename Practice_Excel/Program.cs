// Author: Karl Consing
// 
// Reads a text file and prints to an MS Excel Spreadsheet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Practice_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize
            Application xlapp = new Application();

            // Check if Excel is installed
            if(xlapp == null)
            {
                Console.WriteLine("Excel is not properly installed.");
                return;                
            }

            // Create a new Workbook & Worksheet
            Workbook xlworkbook = xlapp.Workbooks.Add();
            Worksheet xlworksheet = xlworkbook.Worksheets.get_Item(1);

            // Write to worksheet
            xlworksheet.Cells[1, 1] = "My first programmatic excel worksheet";

            // Save
            try
            {
                Console.Write("Save location: ");
                xlworkbook.SaveAs(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Clean
            xlapp.Quit();
            Marshal.ReleaseComObject(xlworkbook);
            Marshal.ReleaseComObject(xlworksheet);
            Marshal.ReleaseComObject(xlapp);


            // Done
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
