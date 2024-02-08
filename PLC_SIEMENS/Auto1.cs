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
    public partial class Auto1 : Form
    {
        Plc plc;
        public Auto1()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();

            cycle_time.Start();
        }

        private void cycle_time_Tick(object sender, EventArgs e)
        {            
            bool zmienna_zezwolenie = (bool)plc.Read("DB30.DBX1.3");
            bool zmienna_uruchamianie = (bool)plc.Read("DB30.DBX1.4");

            if (zmienna_uruchamianie == true)
            {
                zezwolenie_label.Text = "TRWA URUCHAMIANIE";
                zezwolenie_label.ForeColor = Color.Coral;
            }
            else 
            {
                if (zmienna_zezwolenie == true)
                {
                    zezwolenie_label.Text = "ZEZWOLONO";
                    zezwolenie_label.ForeColor = Color.Blue;
                }
                else
                {
                    zezwolenie_label.Text = "NIE ZEZWOLONO";
                    zezwolenie_label.ForeColor = Color.Red;
                }
            }                       
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB30.DBX1.6", true);
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            plc.Write("DB30.DBX1.7", true);
        }

        private void droga01_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga01_check.Checked == true)
            {
                plc.Write("DB30.DBX0.0", true);
            }
            else
            {
                plc.Write("DB30.DBX0.0", false);
            }
        }

        private void droga02_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga02_check.Checked == true)
            {
                plc.Write("DB30.DBX0.1", true);
            }
            else
            {
                plc.Write("DB30.DBX0.1", false);
            }
        }

        private void droga03_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga03_check.Checked == true)
            {
                plc.Write("DB30.DBX0.2", true);
            }
            else
            {
                plc.Write("DB30.DBX0.2", false);
            }
        }

        private void droga04_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga04_check.Checked == true)
            {
                plc.Write("DB30.DBX0.3", true);
            }
            else
            {
                plc.Write("DB30.DBX0.3", false);
            }
        }

        private void droga05_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga05_check.Checked == true)
            {
                plc.Write("DB30.DBX0.4", true);
            }
            else
            {
                plc.Write("DB30.DBX0.4", false);
            }
        }

        private void droga06_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga06_check.Checked == true)
            {
                plc.Write("DB30.DBX0.5", true);
            }
            else
            {
                plc.Write("DB30.DBX0.5", false);
            }
        }

        private void droga07_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga07_check.Checked == true)
            {
                plc.Write("DB30.DBX0.6", true);
            }
            else
            {
                plc.Write("DB30.DBX0.6", false);
            }
        }

        private void droga08_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga08_check.Checked == true)
            {
                plc.Write("DB30.DBX0.7", true);
            }
            else
            {
                plc.Write("DB30.DBX0.7", false);
            }
        }

        private void droga09_check_CheckedChanged(object sender, EventArgs e)
        {
            if (droga09_check.Checked == true)
            {
                plc.Write("DB30.DBX1.0", true);
            }
            else
            {
                plc.Write("DB30.DBX1.0", false);
            }
        }
    }    
}
