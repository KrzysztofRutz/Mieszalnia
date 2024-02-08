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
using System.IO;
namespace PLC_SIEMENS
{
    public partial class Wykresy : Form
    {
        Plc plc;       
        public Wykresy()
        {
            InitializeComponent();
            plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            plc.Open();           
        }


        private void cycle_chart_Tick(object sender, EventArgs e)
        {
            
            //string actual_time = DateTime.Now.ToLongTimeString();
            //double var = Convert.ToDouble(plc.Read(DataType.DataBlock, 10, 40, VarType.Real, 1));
            //amper_chart.Series[0].Points.AddXY(actual_time, var);
        }

        private void Wykresy_Load(object sender, EventArgs e)
        {
            string filepath1 = "P1_value.txt";
            string filepath2 = "P1_date.txt";

            string[] date = File.ReadAllLines(filepath2).ToArray();
            string[] text = File.ReadAllLines(filepath1).ToArray();


            for (int i = 0; i < date.Length; i++)
            {
                amper_chart.Series[0].Points.AddXY(date[i], text[i]);
            }
        }
    }
}
