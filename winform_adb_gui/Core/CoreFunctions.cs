using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.Core
{
    public static class CoreFunctions
    {
        public static void SetUsbFunctions(string functions = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(functions))
                {
                    functions = "none"; // Default to charging mode
                }

                string adbCommand = $"adb shell svc usb setFunctions {functions}";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + adbCommand,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine($"Error setting USB functions: {error}");
                    }
                    else
                    {
                        Console.WriteLine($"Successfully set USB functions to: {functions}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
