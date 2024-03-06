using System;
using PLC_SIEMENS.Definitions;
using System.Windows.Forms;
using S7.Net;

namespace PLC_SIEMENS
{
    public partial class Parametry_podstawowe : Form
    {         
        public Parametry_podstawowe()
        {
            InitializeComponent();
            InitValue();            
        }

        private async void InitValue()
        {
            var t_ze = await PLC.analog_read(11, 4, VarType.Int) / 1000;
            var t_re = await PLC.analog_read(11, 6, VarType.Int) / 1000;
            var t_nap = await PLC.analog_read(11, 8, VarType.Int);
            var t_opr_dr = await PLC.analog_read(11, 0, VarType.Int);

            t_ze_text.Text = t_ze.ToString();
            t_re_text.Text = t_re.ToString();
            t_nap_text.Text = t_nap.ToString();
            t_opr_dr_text.Text = t_opr_dr.ToString();
        }

        private async void t_ze_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_ze_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_ze = Convert.ToInt16(t_ze_text.Text);
                int t_ze_pom = t_ze * 1000;
                if (t_ze_pom > 15000 & t_ze_text.TextLength != 0)
                {
                    t_ze_pom = 15000;
                    t_ze_text.Text = "15";
                }
                else if (t_ze_pom < 1000 & t_ze_text.TextLength != 0)
                {
                    t_ze_pom = 1000;
                    t_ze_text.Text = "1";                    
                }             
                short t_ze_pom1 = Convert.ToInt16(t_ze_pom);
                await PLC.analog_write("DB11.DBW4", t_ze_pom1);
            }
        }

        private async void t_re_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_re_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_re = Convert.ToInt16(t_re_text.Text);
                int t_re_pom = t_re * 1000;
                if (t_re_pom > 7000 & t_re_text.TextLength != 0)
                {
                    t_re_pom = 7000;
                    t_re_text.Text = "7";                   
                }           
                else if (t_re_pom < 1000 & t_re_text.TextLength != 0)
                {
                    t_re_pom = 1000;
                    t_re_text.Text = "1";                                        
                }               
                short t_re_pom1 = Convert.ToInt16(t_re_pom);
                await PLC.analog_write("DB11.DBW6", t_re_pom1);
            }           
        }

        private async void t_nap_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_nap_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_nap = Convert.ToInt16(t_nap_text.Text);
                if (t_nap > 60 & t_nap_text.TextLength != 0)
                {
                    t_nap = 60;
                    t_nap_text.Text = (t_nap).ToString();
                }
                else if (t_nap < 1 & t_nap_text.TextLength != 0)
                {
                    t_nap = 1;
                    t_nap_text.Text = (t_nap).ToString();
                }
                await PLC.analog_write("DB11.DBW8", t_nap);
            }
        }

        private async void opr_dr_text_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (t_opr_dr_text.TextLength == 0)
            {
                t_opr_dr_text.Text = string.Empty; 
            }
            else
            {
                short t_opr = Convert.ToInt16(t_opr_dr_text.Text);
                if (t_opr > 600 & t_opr_dr_text.TextLength != 0)
                {
                    t_opr = 600;
                    t_opr_dr_text.Text = (t_opr).ToString();
                }
                else if (t_opr < 10 & t_opr_dr_text.TextLength != 0)
                {
                    t_opr = 10;
                    t_opr_dr_text.Text = (t_opr).ToString();
                }
                await PLC.analog_write("DB11.DBW0", t_opr);
            }
        }
    }
}
