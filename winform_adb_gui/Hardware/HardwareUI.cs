using System.Collections.Generic;
using System.Windows.Forms;

namespace winform_adb_gui.Hardware
{
    public static class HardwareUI
    {
        public static GroupBox CreateHardwareUI()
        {
            // Create GroupBox
            GroupBox hardwareGroup = new GroupBox
            {
                Text = "Hardware",
                Width = 400,
                Height = 200,
                Left = 10,
                Top = 10
            };

            // Fetch data from HardwareInfo
            var deviceInfo = new Dictionary<string, string>
            {
                { "Model No", HardwareInfo.GetModelNo() },
                { "Brand Name", HardwareInfo.GetBrandName() },
                { "Manufacturer Name", HardwareInfo.GetManufacturerName() },
                { "Market Name", HardwareInfo.GetMarketName() }
            };

            int yPos = 30;

            // Create labels dynamically
            foreach (var item in deviceInfo)
            {
                Label keyLabel = new Label
                {
                    Text = item.Key + ":",
                    Left = 20,
                    Top = yPos,
                    Width = 150
                };

                Label valueLabel = new Label
                {
                    Text = item.Value,
                    Left = 180,
                    Top = yPos,
                    Width = 200
                };

                hardwareGroup.Controls.Add(keyLabel);
                hardwareGroup.Controls.Add(valueLabel);

                yPos += 30;
            }

            return hardwareGroup;
        }
    }
}
