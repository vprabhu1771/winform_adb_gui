using winform_adb_gui.Core;
using winform_adb_gui.Hardware;

namespace winform_adb_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true
            };

            // Create the hardware UI and add it to the form
            panel.Controls.Add(HardwareUI.CreateHardwareUI());

            // Create and add Core UI section
            panel.Controls.Add(CoreUI.CreateCoreUI());

            this.Controls.Add(panel);
        }
    }
}
