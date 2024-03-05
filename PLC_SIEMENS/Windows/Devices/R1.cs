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
    public partial class R1 : Form
    {
        Plc plc;
        public R1()
        {
            InitializeComponent();            
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();
            double textbox = (Convert.ToDouble(SV_analog_suwak.Value / 276.48));
            SV_analog_textbox.Text = textbox.ToString("0.##") + " " + "%";
            short analog =Convert.ToInt16(plc.Read(DataType.DataBlock, 11, 18, VarType.Int, 1));
            SV_analog_suwak.Value = analog;

        }

        private void SV_analog_ValueChanged(object sender, EventArgs e)
        {            
            short analog_write = Convert.ToInt16(SV_analog_suwak.Value); 
            plc.Write("DB11.DBW18",analog_write);           
            double textbox = (Convert.ToDouble(SV_analog_suwak.Value / 276.48));
            SV_analog_textbox.Text = textbox.ToString("0.##") + " " + "%";
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB7.DBX0.0", true);
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB7.DBX40.0", true);
        }

        
       
        private void cycle_alarmy_Tick_1(object sender, EventArgs e)
        {
            bool[] bit_alarm = new bool[4];
            var lDict = new Dictionary<string, Label>();

            lDict["l0"] = alarm1_label;
            lDict["l1"] = alarm2_label;
            lDict["l2"] = alarm3_label;
            lDict["l3"] = alarm4_label;

            bit_alarm[0] = (bool)plc.Read("DB1.DBX2.0");
            bit_alarm[1] = (bool)plc.Read("DB1.DBX2.1");
            bit_alarm[2] = (bool)plc.Read("DB1.DBX2.2");
            bit_alarm[3] = (bool)plc.Read("DB1.DBX2.3");

            for (int i = 0; i<=3; i++)
            {
                if (bit_alarm[i] == true)
                {
                    var label = lDict["l" + i.ToString()];
                    label.Text = "ALARM";
                    label.ForeColor = Color.Red;
                }
                else if (bit_alarm[i] == false)
                {
                    var label = lDict["l" + i.ToString()];
                    label.Text = "OK";
                    label.ForeColor = Color.Blue;
                }
            }           
        }

        private void cycle_stany_Tick(object sender, EventArgs e)
        {
            bool bit_on = (bool)plc.Read("DB6.DBX0.0");
            bool bit_awaria = (bool)plc.Read("DB6.DBX0.1");


            if (bit_on == true)
            {
                stan_label.Text = "PRACUJE";
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

       
    }
}
