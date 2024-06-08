using PLC_SIEMENS.Definitions;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows
{
    public partial class Error_PLC : Form
    {      
        public Error_PLC()
        {
            InitializeComponent();
        }

        private async void Error_PLC_Load(object sender, System.EventArgs e)
        {
            Main.instance.program_cycle.Stop();

            while (!PLC.plc.IsConnected)
            {
                await PLC.connect();
            }

            if (PLC.plc.IsConnected)
            {               
                Close();
            }
        }

        private void Error_PLC_FormClosed(object sender, FormClosedEventArgs e)
        {           
            Main.instance.program_cycle.Start();
        }

        private void CloseApp_button_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
