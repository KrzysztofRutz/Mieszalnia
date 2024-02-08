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
    public partial class Instrukcja : Form
    {
        public Instrukcja()
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
