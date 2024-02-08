using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
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
            Z1_textbox.Text = Main.instance.z1_name.Text;
            Z2_textbox.Text = Main.instance.z2_name.Text;           
        }

        public void save_button_Click(object sender, EventArgs e)
        {
            string filepath = "OpisyZ.txt";
            string[] name = new string[2];
            //List<string> line = new List<string>();
            //line = File.ReadAllLines(filepath).ToList();
            File.Delete(filepath);
            StreamWriter sw = new StreamWriter(filepath);
           
            
            name[0] = Z1_textbox.Text;
            name[1] = Z2_textbox.Text;           
            
            for(int i=0; i<=1; i++)
            {
                sw.WriteLine(name[i]);
            }

            Main.instance.z1_name.Text = name[0];
            Main.instance.z2_name.Text = name[1];           
            sw.Close();      
        }

    }
}
