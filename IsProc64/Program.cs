using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsProc64
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    var name = GetProcessFullName(process);
                    Console.WriteLine($"{name}");
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }

        private static string GetProcessFullName(Process process)
        {
            try
            {
                var name = process.MainModule.FileName;
                return name;
            }
            catch (Win32Exception)
            {
                return "";
            }
        }
    }
}
