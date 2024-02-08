using S7.Net;
using S7.Net.Protocol;
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
    public partial class Parametry_podstawowe : Form
    {
        Plc plc;
        
        public Parametry_podstawowe()
        {
            InitializeComponent();
            
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();
            short t_ze = Convert.ToInt16(plc.Read(DataType.DataBlock, 11, 4, VarType.Int, 1));
            short t_re = Convert.ToInt16(plc.Read(DataType.DataBlock, 11, 6, VarType.Int, 1));
            short t_nap = Convert.ToInt16(plc.Read(DataType.DataBlock, 11, 8, VarType.Int, 1));
            short t_opr = Convert.ToInt16(plc.Read(DataType.DataBlock, 11, 0, VarType.Int, 1));
            t_ze_text.Text = (t_ze / 1000).ToString();
            t_re_text.Text = (t_re / 1000).ToString();
            t_nap_text.Text = t_nap.ToString();
            t_opr_dr_text.Text = t_opr.ToString();

        }

        private void t_ze_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_ze_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_ze = Convert.ToInt16(t_ze_text.Text);
                int t_ze_pom = t_ze * 1000;
                if (t_ze_pom > 15000)
                {
                    t_ze_pom = 15000;
                    t_ze_text.Text = "15";
                    short t_ze_pom1 = Convert.ToInt16(t_ze_pom);
                    plc.Write("DB11.DBW4", t_ze_pom1);
                }
                else if (t_ze_pom < 1000)
                {
                    t_ze_pom = 1000;
                    t_ze_text.Text = "1";
                    short t_ze_pom1 = Convert.ToInt16(t_ze_pom);
                    plc.Write("DB11.DBW4", t_ze_pom1);
                }
                else
                {
                    short t_ze_pom1 = Convert.ToInt16(t_ze_pom);
                    plc.Write("DB11.DBW4", t_ze_pom1);
                }
            }
        }

        private void t_re_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_re_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_re = Convert.ToInt16(t_re_text.Text);
                int t_re_pom = t_re * 1000;
                if (t_re_pom > 7000)
                {
                    t_re_pom = 7000;
                    t_re_text.Text = "7";
                    short t_re_pom1 = Convert.ToInt16(t_re_pom);
                    plc.Write("DB11.DBW6", t_re_pom1);
                }           
                else if (t_re_pom < 1000)
                {
                    t_re_pom = 1000;
                    t_re_text.Text = "1";
                    short t_re_pom1 = Convert.ToInt16(t_re_pom);
                    plc.Write("DB11.DBW6", t_re_pom1);
                }
                else
                {
                    short t_re_pom1 = Convert.ToInt16(t_re_pom);
                    plc.Write("DB11.DBW6", t_re_pom1);
                }
                
            }
           
        }

        private void t_nap_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_nap_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_nap = Convert.ToInt16(t_nap_text.Text);
                if (t_nap > 60)
                {
                    t_nap = 60;
                    t_nap_text.Text = (t_nap).ToString();
                    plc.Write("DB11.DBW8", t_nap);
                }
                else if (t_nap < 1)
                {
                    t_nap = 1;
                    t_nap_text.Text = (t_nap).ToString();
                    plc.Write("DB11.DBW8", t_nap);
                }
                else
                {
                    plc.Write("DB11.DBW8", t_nap);
                }
                
            }
        }

        private void opr_dr_text_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (t_opr_dr_text.TextLength == 0)
            {
                return;
            }
            else
            {
                short t_opr = Convert.ToInt16(t_opr_dr_text.Text);
                if (t_opr > 600)
                {
                    t_opr = 600;
                    t_opr_dr_text.Text = (t_opr).ToString();
                    plc.Write("DB11.DBW0", t_opr);
                }
                else if (t_opr < 10)
                {
                    t_opr = 10;
                    t_opr_dr_text.Text = (t_opr).ToString();
                    plc.Write("DB11.DBW0", t_opr);
                }
                else
                {
                    plc.Write("DB11.DBW0", t_opr);
                }

            }
        }
    }
}
