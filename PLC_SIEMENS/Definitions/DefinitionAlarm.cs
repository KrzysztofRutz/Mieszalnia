using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PLC_SIEMENS.Definitions
{
    public static class DefinitionAlarm
    {
        public static string[] Variable {  get; private set; }
        public static string[] Text { get; private set; }

        public static async Task init()
        {          
            string file = "C:\\Users\\krzys\\OneDrive\\Pulpit\\UMG\\_Praca inżynierska\\SCADA\\PLC_SIEMENS\\PLC_SIEMENS\\Alarmy.csv";

            string[] variable = new string[0];
            string[] text = new string[0];

            await Task.Run(() =>
            {
                using (var stream = new StreamReader(file))
                {
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();
                        string[] fields = line.Split(';');

                        if (fields.Length >= 3)
                        {
                            // Dodaj wartości z pierwszej kolumny do 'column1'
                            Array.Resize(ref variable, variable.Length + 1);
                            variable[variable.Length - 1] = fields[1];

                            // Dodaj wartości z drugiej kolumny do 'column2'
                            Array.Resize(ref text, text.Length + 1);
                            text[text.Length - 1] = fields[2];
                        }
                    }
                }
                Variable = variable;
                Text = text;
            });            
            /*await Task.Run(() =>
            {
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    variable[row - 2] = range.Cells[row, 2].Text;
                    text[row - 2] = range.Cells[row, 3].Text;                  
                }
                book.Close();
                App.Quit();
            });  */         
        }
    }
}
