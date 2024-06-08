using System;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows
{
    public partial class UserManual : Form
    {
        public UserManual()
        {
            InitializeComponent();
        }

        private void Instrukcja_Load(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.FileName = "C:\\SCADA\\C#_programy\\PLC_SIEMENS\\PLC_SIEMENS\\bin\\Debug\\Instrukcja.pdf";

            op.OpenFile();
            InstrukcjaPDF.src = op.FileName;
        }
    }
}
