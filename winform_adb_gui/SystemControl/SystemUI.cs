using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.SystemControl
{
    public static class SystemUI
    {
        public static GroupBox CreateSystemUI()
        {
            // Create GroupBox for Android System Controls
            GroupBox systemGroup = new GroupBox
            {
                Text = "Android System",
                Width = 300,
                Height = 450,
                Left = 10,
                Top = 10
            };

            int yPos = 30;

            // Create Buttons
            Button btnShutdown = CreateButton("Shut Down", yPos, (s, e) => SystemFunctions.ShutdownDevice());
            systemGroup.Controls.Add(btnShutdown);
            yPos += 40;

            Button btnReboot = CreateButton("Reboot", yPos, (s, e) => SystemFunctions.RebootDevice());
            systemGroup.Controls.Add(btnReboot);
            yPos += 40;

            Button btnBootloader = CreateButton("Bootloader Mode", yPos, (s, e) => SystemFunctions.BootloaderMode());
            systemGroup.Controls.Add(btnBootloader);
            yPos += 40;

            Button btnLock = CreateButton("Lock Screen", yPos, (s, e) => SystemFunctions.LockScreen());
            systemGroup.Controls.Add(btnLock);
            yPos += 40;

            Button btnWake = CreateButton("Wake Screen", yPos, (s, e) => SystemFunctions.WakeScreen());
            systemGroup.Controls.Add(btnWake);
            yPos += 40;

            Button btnSwipe = CreateButton("Wake & Swipe Up", yPos, (s, e) => SystemFunctions.WakeScreenAndSwipeUp());
            systemGroup.Controls.Add(btnSwipe);
            yPos += 40;

            // Password field
            Label passLabel = new Label
            {
                Text = "Password:",
                Left = 20,
                Top = yPos + 5,
                Width = 100
            };
            systemGroup.Controls.Add(passLabel);

            TextBox passwordBox = new TextBox
            {
                Left = 100,
                Top = yPos,
                Width = 150,
                PasswordChar = '*'
            };
            systemGroup.Controls.Add(passwordBox);
            yPos += 40;

            Button btnPassword = CreateButton("Wake, Swipe & Enter Password", yPos,
                (s, e) => SystemFunctions.WakeAndSwipeAndEnterPassword(passwordBox.Text));
            btnPassword.Width = 220;
            systemGroup.Controls.Add(btnPassword);

            return systemGroup;
        }

        private static Button CreateButton(string text, int top, EventHandler onClick)
        {
            return new Button
            {
                Text = text,
                Left = 20,
                Top = top,
                Width = 200,
                Height = 30,
                FlatStyle = FlatStyle.System
            }.Also(btn => btn.Click += onClick);
        }

        // Small helper to attach event in fluent style
        private static T Also<T>(this T control, Action<T> action)
        {
            action(control);
            return control;
        }
    }
}
