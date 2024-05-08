using System;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class ElectricalDiagram : Form
    {
        public ElectricalDiagram()
        {
            InitializeComponent();
        }

        private void Schemat_Load(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.FileName = "C:\\SCADA\\C#_programy\\PLC_SIEMENS\\PLC_SIEMENS\\bin\\Debug\\Schemat.pdf";
                       
            op.OpenFile();
            schematPDF.src = op.FileName;        
        }
    }
}
