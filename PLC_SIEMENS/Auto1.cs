using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class Auto1 : Form
    {        
        public Auto1()
        {
            InitializeComponent();            
            cycle_time.Start();
        }

        private async void cycle_time_Tick(object sender, EventArgs e)
        {            
            bool zmienna_zezwolenie = await PLC.readBool("DB30.DBX1.3");
            bool zmienna_uruchamianie = await PLC.readBool("DB30.DBX1.4");

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

        private async void start_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB30.DBX1.6", true);
        }

        private async void stop_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB30.DBX1.7", true);
        }

        private async Task AutoChecked(CheckBox checkbox, string variable)
        {
            if (checkbox.Checked) await PLC.writeBool(variable, true);          
            else await PLC.writeBool(variable, false);
        }

        private async void droga01_check_CheckedChanged(object sender, EventArgs e)
        {
            await AutoChecked(droga01_check, "DB30.DBX0.0");
        }

        private async void droga02_check_CheckedChanged(object sender, EventArgs e)
        {
            await AutoChecked(droga02_check, "DB30.DBX0.1");
        }

        private async void droga03_check_CheckedChanged(object sender, EventArgs e)
        {
            await AutoChecked(droga03_check, "DB30.DBX0.2");
        }

        private async void droga04_check_CheckedChanged(object sender, EventArgs e)
        {
            await AutoChecked(droga04_check, "DB30.DBX0.3");
        }       
    }    
}
