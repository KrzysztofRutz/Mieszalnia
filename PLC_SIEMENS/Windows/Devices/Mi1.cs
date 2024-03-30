using PLC_SIEMENS.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Devices
{
    public partial class Mi1 : Form
    {
        public Mi1()
        {
            InitializeComponent();
        }

        private async void start_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB7.DBX0.0", true);
        }

        private async void stop_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB7.DBX2.0", true);
        }

        private async void cycle_stany_Tick(object sender, EventArgs e)
        {
            bool bit_on = await PLC.readBool("DB6.DBX0.0");
            bool bit_awaria = await PLC.readBool("DB6.DBX0.1");

            if (bit_on) stan_label.Text = "PRACUJE";
            else if (bit_awaria) stan_label.Text = "ALARM";
            else stan_label.Text = "ZATRZYMANY";
        }
    }
}
