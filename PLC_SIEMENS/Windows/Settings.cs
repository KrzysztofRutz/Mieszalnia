using System;
using PLC_SIEMENS.Definitions;
using System.Windows.Forms;
using S7.Net;

namespace PLC_SIEMENS.Windows
{
    public partial class Settings : Form
    {         
        public Settings()
        {
            InitializeComponent();
            InitValue();            
        }

        private async void InitValue()
        {
            var t_mieszania = await PLC.analog_read(11, 0, VarType.Int);
            var weight_start_W1 = await PLC.analog_read(11, 4, VarType.Real);

            t_mieszania_text.Text = t_mieszania.ToString();
            weight_start_W1_text.Text = weight_start_W1.ToString();
        }

        private async void t_mieszania_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (t_mieszania_text.TextLength != 0)
                {
                    short t_mieszania = Convert.ToInt16(t_mieszania_text.Text);
                    if (t_mieszania > 20)
                    {
                        t_mieszania = 20;
                        t_mieszania_text.Text = "20";
                    }
                    else if (t_mieszania < 1)
                    {
                        t_mieszania = 1;
                        t_mieszania_text.Text = "1";
                    }
                    short t_mieszania_pom1 = Convert.ToInt16(t_mieszania);
                    await PLC.analog_write("DB11.DBW0", t_mieszania_pom1);
                }
            }
            catch (FormatException) 
            {
                double t_mieszania1 = Math.Round(Convert.ToDouble(t_mieszania_text.Text));
                t_mieszania_text.Text = t_mieszania1.ToString();
            }
            
        }

        private async void weight_start_W1_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (weight_start_W1_text.TextLength != 0)
            {
                try
                {
                    float weight_start_W1 = Convert.ToSingle(weight_start_W1_text.Text);
                    if (weight_start_W1 > 2)
                    {
                        //weight_start_W1 = 2;
                        weight_start_W1_text.Text = "2";
                    }
                    else if (weight_start_W1 < 0.1)
                    {
                        //weight_start_W1 = 0.1;
                        weight_start_W1_text.Text = "0,1";
                    }
                    float weight_start_W1_pom1 = Convert.ToSingle(weight_start_W1);
                    await PLC.analog_write("DB11.DBD4", weight_start_W1_pom1);
                }
                catch { }
            }                    
        }       
    }
}
