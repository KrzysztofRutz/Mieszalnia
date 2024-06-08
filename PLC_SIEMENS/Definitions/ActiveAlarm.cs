using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PLC_SIEMENS.Definitions
{
    public static class ActiveAlarm
    {
        public static async Task Detect()
        {
            await PLC.writeBool("DB8.DBX0.7", true);
            bool isconnect = false;

            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = localhost; Initial Catalog = Mieszalnia; Integrated Security = true");
            try
            {
                await conn.OpenAsync();
                isconnect = true;
            }
            catch
            {
                conn.Dispose();
                isconnect = false;
            }

            if (isconnect)
            {
                await Task.Run(async () =>
                {
                    for (int row = 0; row < DefinitionAlarm.Variable.Count(); row++)
                    {
                        string zmienna = DefinitionAlarm.Variable[row];
                        bool variable_al = await PLC.readBool(zmienna);
                        if (variable_al)
                        {
                            var datestart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string alarm_name = DefinitionAlarm.Text[row];
                            var check_alarm = new SqlCommand($"SELECT id FROM Alarm WHERE Descrip='{alarm_name}' AND DateEnd is NULL;", conn);
                            var reader_check_alarm = await check_alarm.ExecuteReaderAsync();
                            int id = 0;
                            using (reader_check_alarm)
                            {
                                while (await reader_check_alarm.ReadAsync())
                                {
                                    id = reader_check_alarm.GetInt32(0);
                                }
                            }

                            if (id == 0)
                            {
                                var command = new SqlCommand($"INSERT INTO Alarm (DateStart, Descrip) VALUES ('{datestart}', '{alarm_name}');", conn);
                                using (command) await command.ExecuteNonQueryAsync();
                            }
                        }
                        else continue;
                    }
                    conn.Close();
                });
            }
        }

        public static async Task Delete()
        {
            bool isconnect = false;

            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = localhost; Initial Catalog = Mieszalnia; Integrated Security = true");
            try
            {
                await conn.OpenAsync();
                isconnect = true;
            }
            catch
            {
                conn.Dispose();
                isconnect = false;
            }

            if (isconnect)
            {
                await Task.Run(async () =>
                {
                    for (int row = 0; row < DefinitionAlarm.Variable.Count(); row++)
                    {
                        string zmienna = DefinitionAlarm.Variable[row];
                        bool variable_al = await PLC.readBool(zmienna);
                        if (!variable_al)
                        {
                            var datestart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string column = "C" + row;
                            string alarm_name = DefinitionAlarm.Text[row];

                            var command_check = new SqlCommand($"SELECT id FROM Alarm WHERE DateEnd is NULL AND Descrip = '{alarm_name}';", conn);
                            var reader_check = await command_check.ExecuteReaderAsync();
                            int check = 0;
                            using (reader_check)
                            {
                                while (await reader_check.ReadAsync())
                                {
                                    check = reader_check.GetInt32(0);
                                }
                            }

                            if (check != 0)
                            {
                                var command = new SqlCommand($"UPDATE Alarm SET DateEnd = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE DateEnd is NULL AND Descrip = '{alarm_name}';", conn);
                                using (command) await command.ExecuteNonQueryAsync();
                            }
                        }
                        else continue;
                    }
                    conn.Close();
                });
            }
        }
    }
}
