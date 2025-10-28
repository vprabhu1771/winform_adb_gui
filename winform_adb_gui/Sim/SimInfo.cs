using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.Sim
{
    public static class SimInfo
    {
        // Run ADB and return output
        private static string RunAdbCommand(string command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + command,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string result = process.StandardOutput.ReadToEnd().Trim();
                    process.WaitForExit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Get SIM vendor names
        public static List<string> GetSimVendors()
        {
            string result = RunAdbCommand("adb shell getprop gsm.operator.alpha").Trim(',');

            if (string.IsNullOrEmpty(result))
                return new List<string> { "Unknown SIM vendor info" };

            var simVendors = new List<string>();
            foreach (var vendor in result.Split(','))
            {
                string cleaned = vendor.Trim();
                if (!string.IsNullOrEmpty(cleaned))
                    simVendors.Add(cleaned);
            }

            return simVendors;
        }

        // Get phone number (if available)
        public static string GetPhoneInfo()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c adb shell service call iphonesubinfo 19",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                        return "Error executing ADB command";

                    // Parse result text roughly like the Python version
                    string[] parts = output.Split('\'');
                    if (parts.Length > 1)
                    {
                        string phone = parts[1]
                            .Replace("\n", "")
                            .Replace(".", "")
                            .Trim();

                        if (!string.IsNullOrEmpty(phone))
                            return phone;
                    }

                    return "No phone number found";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
