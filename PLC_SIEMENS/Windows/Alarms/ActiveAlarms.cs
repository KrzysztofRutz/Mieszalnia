using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class ActiveAlarms :Form
    {      
        public ActiveAlarms()
        {
            InitializeComponent();           
        }

        private async void Alarmy_aktywne_Load(object sender, EventArgs e)
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
                var command_count = new SqlCommand($"SELECT COUNT(id) FROM Alarm WHERE DateEnd is NULL;", conn);
                var reader_count = await command_count.ExecuteReaderAsync();
                using (reader_count)
                {
                    while(await reader_count.ReadAsync()) 
                    {
                        count_alarms = reader_count.GetInt32(0);
                    }
                }

                DateTime[] date = new DateTime[count_alarms];
                string[] alarm_text = new string[count_alarms];
                var command = new SqlCommand($"SELECT DateStart, Descrip FROM Alarm WHERE DateEnd is NULL;", conn);
                var reader = await command.ExecuteReaderAsync();
                using (reader)
                {
                    int i = 0;
                    while (await reader.ReadAsync())
                    {
                        date[i] = reader.GetDateTime(0);
                        alarm_text[i] = reader.GetString(1);
                        i++;
                    }
                }

                for (int row = 0; row < count_alarms; row++) alarmy_grid.Rows.Add(date[row].ToString(), alarm_text[row]);

                await Task.Run(() =>
                {                   
                    conn.Close();
                });
            }           
        }
    }
}
