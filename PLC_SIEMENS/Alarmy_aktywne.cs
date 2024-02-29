using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace PLC_SIEMENS
{
    public partial class Alarmy_aktywne :Form
    {
        //Plc plc;
        public Alarmy_aktywne()
        {
            InitializeComponent();
           
        }

        private async void Alarmy_aktywne_Load(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application App;
            Workbook book;
            Worksheet sheet;
            Range range;

            string file = "C:\\Users\\krzys\\OneDrive\\Pulpit\\UMG\\_Praca inżynierska\\SCADA\\PLC_SIEMENS\\PLC_SIEMENS\\Alarmy.xlsx";

            if (file != string.Empty)
            {
                App = new Microsoft.Office.Interop.Excel.Application();
                book = await Task.Run(() => App.Workbooks.Open(file));
                sheet = book.Worksheets["Alarmy"];
                range = sheet.UsedRange;

                for (int row = 2; row <= range.Rows.Count; row++)
                {

                    string zmienna = range.Cells[row, 2].Text;
                    bool j = await PLC.readBool(zmienna);
                    if (j == true)
                    {
                        string data = DateTime.Now.ToLongDateString();
                        string czas = DateTime.Now.ToLongTimeString();
                        string alarm_date = data + " " + czas;
                        //alarmy_grid.Rows.Add(alarm_date, range.Cells[row, 3].Text)
                        await Task.Run(() => alarmy_grid.Rows.Add(range.Cells[row, 4].Text, range.Cells[row, 3].Text));
                    }
                    else
                    {
                        continue;
                    }
                    //alarmy_grid.Rows.Add(range.Cells[row, 2].Text, range.Cells[row, 3].Text);
                }
                await Task.Run(() =>
                {
                    book.Close();
                    App.Quit();
                });
            }
        }
    }
}
