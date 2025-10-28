using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.SystemControl
{
    public static class SystemFunctions
    {

        private static bool RunAdbCommand(string command)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C adb {command}";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                return process.ExitCode == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing ADB command: {ex.Message}");
                return false;
            }
        }

        public static void ShutdownDevice()
        {
            if (RunAdbCommand("shell reboot -p"))
                MessageBox.Show("Device is shutting down!", "Success");
            else
                MessageBox.Show("Failed to shut down device!", "Error");
        }

        public static void RebootDevice()
        {
            if (RunAdbCommand("reboot"))
                MessageBox.Show("Device is rebooting!", "Success");
            else
                MessageBox.Show("Failed to reboot device!", "Error");
        }

        public static void BootloaderMode()
        {
            if (RunAdbCommand("reboot bootloader"))
                MessageBox.Show("Device is entering bootloader mode!", "Success");
            else
                MessageBox.Show("Failed to enter bootloader mode!", "Error");
        }

        public static void LockScreen()
        {
            RunAdbCommand("shell input keyevent 26");
        }

        public static void WakeScreen()
        {
            RunAdbCommand("shell input keyevent 26");
        }

        public static void WakeScreenAndSwipeUp()
        {
            RunAdbCommand("shell input keyevent 26");
            Thread.Sleep(2000);
            RunAdbCommand("shell input swipe 500 1500 500 500");
        }

        public static void WakeAndSwipeAndEnterPassword(string password)
        {
            RunAdbCommand("shell input keyevent 26");
            Thread.Sleep(2000);
            RunAdbCommand("shell input swipe 500 1500 500 500");
            Thread.Sleep(2000);

            foreach (char c in password)
            {
                RunAdbCommand($"shell input text {c}");
            }

            RunAdbCommand("shell input keyevent 66"); // Enter
        }
    }

}
