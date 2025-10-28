using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_adb_gui.Sim
{
    public static class SimUI
    {
        public static GroupBox CreateSimUI()
        {
            // Create GroupBox
            GroupBox simGroup = new GroupBox
            {
                Text = "SIM Information",
                Width = 300,
                Height = 250,
                Left = 10,
                Top = 10
            };

            // Get SIM vendor info
            List<string> simVendors = SimInfo.GetSimVendors();

            int yPos = 30;
            foreach (var vendor in simVendors)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = vendor,
                    Left = 20,
                    Top = yPos,
                    Width = 250
                };
                simGroup.Controls.Add(checkBox);
                yPos += 25;
            }

            // Add phone info label below SIM vendors
            string phoneNumber = SimInfo.GetPhoneInfo();

            Label phoneLabel = new Label
            {
                Text = $"Phone Number: {phoneNumber}",
                Left = 20,
                Top = yPos + 10,
                Width = 250
            };

            simGroup.Controls.Add(phoneLabel);

            return simGroup;
        }
    }
}
