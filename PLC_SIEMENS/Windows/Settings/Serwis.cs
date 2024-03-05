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
    public partial class Serwis : Form
    {
        Plc plc;
        public Serwis()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();           
        }

        private void obroty_off_check_CheckedChanged(object sender, EventArgs e)
        {
            if (obroty_off_check.Checked == true)
            {
                plc.Write("DB8.DBX5.0", true);
            }
            else
            {
                plc.Write("DB8.DBX5.0", false);
            }
        }
      
        private void prad_off_check_CheckedChanged(object sender, EventArgs e)
        {
            if (prad_off_check.Checked == true)
            {
                plc.Write("DB8.DBX4.7", true);
            }
            else
            {
                plc.Write("DB8.DBX4.7", false);
            }
        }

        private void softstart_off_check_CheckedChanged(object sender, EventArgs e)
        {
            if (softstart_off_check.Checked == true)
            {
                plc.Write("DB8.DBX4.6", true);
            }
            else
            {
                plc.Write("DB8.DBX4.6", false);
            }
        }

        private void pas_off_check_CheckedChanged(object sender, EventArgs e)
        {
            if (pas_off_check.Checked == true)
            {
                plc.Write("DB8.DBX5.1", true);
            }
            else
            {
                plc.Write("DB8.DBX5.1", false);
            }
        }
    }
    
}
