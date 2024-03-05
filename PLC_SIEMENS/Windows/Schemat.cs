using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class Schemat : Form
    {
        public Schemat()
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
