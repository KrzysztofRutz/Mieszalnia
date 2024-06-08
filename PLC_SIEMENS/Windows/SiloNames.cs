using System;
using System.IO;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows
{
    public partial class Opisy_Z : Form
    {
        public static Opisy_Z instance;
        public Opisy_Z()
        {
            InitializeComponent();
            instance = this;                      
        }

        private void Opisy_Z_Load(object sender, EventArgs e)
        {
            Z1_textbox.Text = Main.instance.Z1_name_textbox.Text;
            Z2_textbox.Text = Main.instance.Z2_name_textbox.Text;           
        }

        public void save_button_Click(object sender, EventArgs e)
        {
            string filepath = "OpisyZ.txt";
            string[] name = new string[2];

            File.Delete(filepath);
            StreamWriter sw = new StreamWriter(filepath);
                   
            name[0] = Z1_textbox.Text;
            name[1] = Z2_textbox.Text;           
            
            for(int i=0; i<=1; i++)
            {
                sw.WriteLine(name[i]);
            }

            Main.instance.Z1_name_textbox.Text = name[0];
            Main.instance.Z2_name_textbox.Text = name[1]; 
            
            sw.Close();      
        }
    }
}
