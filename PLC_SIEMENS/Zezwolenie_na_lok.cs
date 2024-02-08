using S7.Net;
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
    public partial class Zezwolenie_na_lok : PLC
    {       
        public Zezwolenie_na_lok()
        {
            InitializeComponent();           
        }

        private void zezwolono_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB8.DBX8.2", true);
        }

        private void nie_zezwolono_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB8.DBX8.2", false);
        }
    }
}
