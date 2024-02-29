using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class Alarmy_historyczne : Form
    {
        //public static Alarmy_historyczne instance;
        public Alarmy_historyczne()
        {
            InitializeComponent();
            //instance = this;
        }

        private async void Alarmy_historyczne_Load(object sender, EventArgs e)
        {
            string filepath1 = "alarm_his_date.txt";
            string filepath2 = "alarm_his_text.txt";
                        
            string[] date = await Task.Run(() => File.ReadAllLines(filepath1).ToArray());
            string[] text = await Task.Run(() => File.ReadAllLines(filepath2).ToArray());

            for (int i = 0; i <date.Length; i++) alarmyhis_grid.Rows.Add(date[i], text[i]);
        }
    }
}
