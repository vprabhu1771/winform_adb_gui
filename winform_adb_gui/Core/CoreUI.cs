using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.Core
{
    public static class CoreUI
    {
        public static GroupBox CreateCoreUI()
        {
            // Create GroupBox similar to LabelFrame
            GroupBox coreGroup = new GroupBox
            {
                Text = "Core",
                Width = 250,
                Height = 150,
                Left = 20,
                Top = 20
            };

            // Create RadioButtons
            RadioButton chargingRadio = new RadioButton
            {
                Text = "Charging",
                Left = 20,
                Top = 30,
                Width = 200,
                Checked = true
            };

            RadioButton fileTransferRadio = new RadioButton
            {
                Text = "File Transfer (MTP)",
                Left = 20,
                Top = 60,
                Width = 200
            };

            // Attach event handlers
            chargingRadio.CheckedChanged += (sender, e) =>
            {
                if (chargingRadio.Checked)
                {
                    CoreFunctions.SetUsbFunctions(); // Default = charging
                    Console.WriteLine("Selected USB mode: charging");
                }
            };

            fileTransferRadio.CheckedChanged += (sender, e) =>
            {
                if (fileTransferRadio.Checked)
                {
                    CoreFunctions.SetUsbFunctions("mtp"); // File transfer
                    Console.WriteLine("Selected USB mode: file_transfer");
                }
            };

            // Add controls to group box
            coreGroup.Controls.Add(chargingRadio);
            coreGroup.Controls.Add(fileTransferRadio);

            return coreGroup;
        }
    }
}
