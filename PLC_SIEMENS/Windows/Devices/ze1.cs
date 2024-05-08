using System;
using System.Windows.Forms;
using PLC_SIEMENS.Definitions;

namespace PLC_SIEMENS.Windows.Devices
{
    public partial class ze1 : Form
    {        
        public ze1()
        {
            InitializeComponent();
        }

        private async void open_button_Click(object sender, EventArgs e)
        {            
            await PLC.writeBool("DB7.DBX1.0", true);
        }

        private async void close_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB7.DBX3.0", true);
        }

        private async void cycle_Tick(object sender, EventArgs e)
        {
            bool bit_open = await PLC.readBool("DB6.DBX2.0");
            bool bit_close = await PLC.readBool("DB6.DBX2.1");
            bool bit_awaria = await PLC.readBool("DB6.DBX2.2");

            if (bit_open == true & bit_awaria == false) stan_label.Text = "OTWARTA";
            else if (bit_close == true & bit_awaria == false) stan_label.Text = "ZAMKNIĘTA";
            else if (bit_awaria == true) stan_label.Text = "ALARM";
            else stan_label.Text = "----";
        }       
    }
}
