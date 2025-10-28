using winform_adb_gui.Core;
using winform_adb_gui.Hardware;

namespace winform_adb_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
            // Create the hardware UI and add it to the form
            GroupBox hardwareBox = HardwareUI.CreateHardwareUI();
            this.Controls.Add(hardwareBox);

            // Create and add Core UI section
            GroupBox coreBox = CoreUI.CreateCoreUI();
            this.Controls.Add(coreBox);
        }
    }
}
