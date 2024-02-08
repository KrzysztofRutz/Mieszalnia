using Microsoft.Office.Interop.Excel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PLC_SIEMENS
{
    public partial class ze3 : Form
    {
        Plc plc;
        public ze3()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();
        }

        private void open_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB7.DBX4.1", true);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB7.DBX44.1", true);
        }

        private void cycle_Tick(object sender, EventArgs e)
        {
            bool bit_open = (bool)plc.Read("DB6.DBX40.6");
            bool bit_close = (bool)plc.Read("DB6.DBX40.7");
            bool bit_awaria = (bool)plc.Read("DB6.DBX41.0");


            if (bit_open == true)
            {
                stan_label.Text = "OTWARTA";
            }
            else if (bit_close == true)
            {
                stan_label.Text = "ZAMKNIĘTA";
            }
            else if (bit_awaria == true)
            {
                stan_label.Text = "ALARM";
            }
            else
            {
                stan_label.Text = "----";
            }
        }

        private void cycle_alarmy_Tick(object sender, EventArgs e)
        {
            bool bit_alarm1 = (bool)plc.Read("DB1.DBX11.2");
            bool bit_alarm2 = (bool)plc.Read("DB1.DBX11.3");

            if (bit_alarm1 == true)
            {
                alarm1_label.Text = "ALARM";
                alarm1_label.ForeColor = Color.Red;
            }
            else if (bit_alarm2 == true)
            {
                alarm2_label.Text = "ALARM";
                alarm2_label.ForeColor = Color.Red;
            }
            else if (bit_alarm1 == false)
            {
                alarm1_label.Text = "OK";
                alarm1_label.ForeColor = Color.Blue;
            }
            else if (bit_alarm2 == false)
            {
                alarm2_label.Text = "OK";
                alarm2_label.ForeColor = Color.Blue;
            }
        }
    }
}
