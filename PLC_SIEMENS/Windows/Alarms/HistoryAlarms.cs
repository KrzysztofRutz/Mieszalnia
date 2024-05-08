using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Alarms
{
    public partial class HistoryAlarms : Form
    {
       
        public HistoryAlarms()
        {
            InitializeComponent();
            StartDatePicker.Value = DateTime.Now.AddDays(-7);
            DateEndPicker.Value = DateTime.Now;
            content_al();
        }

        private async void content_al()
        {
            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog = Mieszalnia; Integrated Security = true");
            bool isconnect = false;
            try
            {
                await conn.OpenAsync();
                isconnect = true;
            }
            catch
            {
                conn.Dispose();
                isconnect = false;
                MessageBox.Show("Brak połączenia z bazą danych.", "Błąd");
            }

            if (isconnect)
            {
                int count_alarms = 0;
                var command_count = new SqlCommand($"SELECT COUNT(id) FROM Alarm WHERE DateStart >= '{StartDatePicker.Value.ToString("yyyy-MM-dd")} 00:00:01' AND DateEnd <= '{DateEndPicker.Value.ToString("yyyy-MM-dd")} 23:59:59' AND DateEnd is not NULL;", conn);
                var reader_count = await command_count.ExecuteReaderAsync();
                using (reader_count)
                {
                    while (await reader_count.ReadAsync())
                    {
                        count_alarms = reader_count.GetInt32(0);
                    }
                }

                DateTime[] datestart = new DateTime[count_alarms];
                DateTime[] dateend = new DateTime[count_alarms];
                string[] alarm_text = new string[count_alarms];
                var command = new SqlCommand($"SELECT DateStart, DateEnd, Descrip FROM Alarm WHERE DateStart >= '{StartDatePicker.Value.ToString("yyyy-MM-dd")} 00:00:01' AND DateEnd <= '{DateEndPicker.Value.ToString("yyyy-MM-dd")} 23:59:59' AND DateEnd is not NULL;", conn);
                var reader = await command.ExecuteReaderAsync();
                using (reader)
                {
                    int i = 0;
                    while (await reader.ReadAsync())
                    {
                        datestart[i] = reader.GetDateTime(0);
                        dateend[i] = reader.GetDateTime(1);
                        alarm_text[i] = reader.GetString(2);
                        i++;
                    }
                }

                for (int row = 0; row < count_alarms; row++) alarmyhis_grid.Rows.Add(datestart[row].ToString(), dateend[row].ToString(), alarm_text[row]);

                await Task.Run(() =>
                {
                    conn.Close();
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alarmyhis_grid.Rows.Clear();
            if (StartDatePicker.Value > DateEndPicker.Value) MessageBox.Show("Błędny zakres dat.", "Błąd");
            else content_al();
        }
    }
}
