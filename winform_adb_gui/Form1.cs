using winform_adb_gui.Core;
using winform_adb_gui.Hardware;
using winform_adb_gui.Sim;
using winform_adb_gui.SystemControl;

namespace winform_adb_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set the window to open maximized
            this.WindowState = FormWindowState.Maximized;

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

            // Create SIM UI and add to form
            panel.Controls.Add(SimUI.CreateSimUI());

            // Add the Android System UI
            panel.Controls.Add(SystemUI.CreateSystemUI());

            this.Controls.Add(panel);
        }
    }
}
