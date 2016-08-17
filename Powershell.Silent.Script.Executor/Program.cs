using System;
using System.IO;

namespace Powershell.Silent.Script.Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Powershell.Silent.Script.Executor.exe <script_to_execute>");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Error: Script " + args[1] + " does not exist or is not accessible");
                return;
            }

            var arguments = new string[] { "-ExecutionPolicy", "bypass", "-file", args[0] };
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "powershell.exe",
                Arguments = string.Join(" ", arguments)

            };

            var process = new System.Diagnostics.Process
            {
                StartInfo = startInfo,

            };
            process.Start();
            process.WaitForExit();
        }
    }
}
