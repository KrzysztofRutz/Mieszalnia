using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using S7.Net;

namespace PLC_SIEMENS
{
    public partial class Alarmy_aktywne : PLC
    {
        //Plc plc;
        public Alarmy_aktywne()
        {
            InitializeComponent();
           //plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
            //plc.Open();
        }

        private void Alarmy_aktywne_Load(object sender, EventArgs e)
        {
            {
                int row;
                Microsoft.Office.Interop.Excel.Application App;
                Workbook book;
                Worksheet sheet;
                Range range;


                string file = "C:\\Users\\krzys\\OneDrive\\Pulpit\\UMG\\_Praca inżynierska\\SCADA\\PLC_SIEMENS\\PLC_SIEMENS\\Alarmy.xlsx";

                if (file != string.Empty)
                {
                    App = new Microsoft.Office.Interop.Excel.Application();
                    book = App.Workbooks.Open(file);
                    sheet = book.Worksheets["Alarmy"];
                    range = sheet.UsedRange;

                    int i = 0;
                    for (row = 2; row <= range.Rows.Count; row++)
                    {

                        string zmienna = range.Cells[row, 2].Text;
                        bool j = (bool)plc.Read(zmienna);
                        if (j == true)
                        {
                            string data = DateTime.Now.ToLongDateString();
                            string czas = DateTime.Now.ToLongTimeString();
                            string alarm_date = data + " " + czas;
                            //alarmy_grid.Rows.Add(alarm_date, range.Cells[row, 3].Text)
                            alarmy_grid.Rows.Add(range.Cells[row,4].Text, range.Cells[row, 3].Text);
                        }
                        else
                        {                            
                            i++;
                        }
                        //alarmy_grid.Rows.Add(range.Cells[row, 2].Text, range.Cells[row, 3].Text);
                    }
                    book.Close();
                    App.Quit();
                }
            }
        }
    }
}
