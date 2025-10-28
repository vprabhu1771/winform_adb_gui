using System;
using System.Diagnostics;

namespace winform_adb_gui.Hardware
{
    public static class HardwareInfo
    {
        private static string RunAdbCommand(string command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + command,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string result = process.StandardOutput.ReadToEnd().Trim();
                    process.WaitForExit();
                    return string.IsNullOrEmpty(result) ? "Unknown" : result;
                }
            }
            catch
            {
                return "Error Running Command";
            }
        }

        public static string GetBrandName()
        {
            return RunAdbCommand("adb shell getprop ro.product.vendor_dlkm.brand");
        }

        public static string GetManufacturerName()
        {
            return RunAdbCommand("adb shell getprop ro.product.vendor_dlkm.manufacturer");
        }

        public static string GetMarketName()
        {
            return RunAdbCommand("adb shell getprop ro.product.vendor.marketname");
        }

        public static string GetModelNo()
        {
            return RunAdbCommand("adb shell getprop ro.product.model");
        }
    }
}
