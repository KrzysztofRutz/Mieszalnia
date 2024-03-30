using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using PLC_SIEMENS.Definitions;
using PLC_SIEMENS.Windows.Devices;
using PLC_SIEMENS.Windows;

namespace PLC_SIEMENS
{
    public partial class Main : Form
    {
        public static Main instance;
        public Main()
        {
            InitializeComponent();
            instance = this;           
            
            //Wpisanie nazw silosów 
            string filepath = "OpisyZ.txt";
            string[] name = new string[2];
            name = File.ReadAllLines(filepath).ToArray();
            z1_name.Text = name[0];
            z2_name.Text = name[1];

            //Załączenie tickerów odczytu danych w czasie rzeczywistym
            main_timer.Start();
            program_cycle.Start();

            init();
        }
      
        private async void init()
        {
            var cykle_sv = Convert.ToInt32(await PLC.analog_read(20, 2, S7.Net.VarType.Int));
            cykle_SV_label.Text = cykle_sv.ToString();
            var wsad_sv = Convert.ToDouble(await PLC.analog_read(20, 4, S7.Net.VarType.Real));
            weight_SV_label.Text = wsad_sv.ToString();
            var cykle_pv = Convert.ToInt32(await PLC.analog_read(20, 0, S7.Net.VarType.Int));
            cykle_PV_label.Text = cykle_pv.ToString();
            var id = Convert.ToInt32(await PLC.analog_read(20, 38, S7.Net.VarType.Int));
            bool isconnect = false;
            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog = Mieszalnia; Integrated Security = true");
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
                var command = new SqlCommand($"SELECT RecipeName FROM Recipes WHERE id={id};", conn);
                var reader = await command.ExecuteReaderAsync();
                using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        recipe_name_label.Text = reader.GetString(0);
                    }
                }
                conn.Close();
            }
        }
        private async void main_timer_Tick(object sender, EventArgs e)
        {
            //Odświeżanie daty i godziny na wizualizacji 
            actual_time.Text = DateTime.Now.ToLongTimeString();
            actual_date.Text = DateTime.Now.ToLongDateString();

            //Jeśli wystąpił nowy alarm to wykonujemy funkcje dodania go do bazy 
            if (await PLC.readBool("DB8.DBX1.0")) await active_alarm();          
        }

        private async Task active_alarm()
        {
            await PLC.writeBool("DB8.DBX0.7", true);
            bool isconnect = false;

            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog = Mieszalnia; Integrated Security = true");
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

                            var command = new SqlCommand($"INSERT INTO Alarm (DateStart, Descrip) VALUES ('{datestart}', '{alarm_name}');", conn);
                            using (command) await command.ExecuteNonQueryAsync();
                        }
                        else continue;
                    }
                    conn.Close();
                });                              
            }
        }

        private async void program_cycle_Tick(object sender, EventArgs e)
        {
            if (PLC.plc.IsConnected)
            {
                await dzwonek();
                await opr_dr_tech();
                await auto();
                await alarm_obiekt();
                await status_line();

                await read_weight_SV(8, skl1_weight_SV_label);
                await read_weight_SV(12, skl2_weight_SV_label);

                var cykle_PV = Convert.ToDouble(await PLC.analog_read(20, 0, S7.Net.VarType.Int));
                cykle_PV_label.Text = cykle_PV.ToString();
                var weight = Convert.ToDouble(await PLC.analog_read(10, 0, S7.Net.VarType.Real));
                weight_label.Text = $"{weight.ToString("0.##")} kg";
                var weight_skl = Convert.ToDouble(await PLC.analog_read(20, 34, S7.Net.VarType.Real));
                skl_weight_PV_label.Text = $"{weight_skl.ToString("0.##")} kg";
                var weight_PV = Convert.ToDouble(await PLC.analog_read(20, 24, S7.Net.VarType.Real));
                weight_PV_label.Text = $"{weight_PV.ToString("0.##")} kg";

                await time_mieszania();

                await napelnienie("DB6.DBX4.0", Z1_pelny);
                await napelnienie("DB6.DBX4.1", Z2_pelny);

                await screw("DB6.DBX0.0", "DB6.DBX0.1", Mi1);
                await wibro("DB6.DBX0.2", "DB6.DBX0.3", Wb1);
                await wibro("DB6.DBX0.4", "DB6.DBX0.5", Wb2);
                await wibro("DB6.DBX0.6", "DB6.DBX0.7", Wb3);

                await zasuwa("DB6.DBX2.0", "DB6.DBX2.1", "DB6.DBX2.2", ZE1);
                await zasuwa("DB6.DBX2.3", "DB6.DBX2.4", "DB6.DBX2.5", ZE2);
                await zasuwa("DB6.DBX2.6", "DB6.DBX2.7", "DB6.DBX3.0", ZE3);

                await drogi("DB5.DBX0.0", odc1_label1);
                await drogi("DB5.DBX0.0", odc1_label2);
                await drogi("DB5.DBX0.0", odc1_label3);
                await drogi("DB5.DBX0.1", odc2_label1);
                await drogi("DB5.DBX0.1", odc2_label2);
                await drogi("DB5.DBX0.1", odc2_label3);
                await drogi("DB5.DBX0.2", odc3_label);
            }
            else await PLC.connect();
        }

        private void close_app_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy napewno chcesz wyjść z aplikacji?", "Zamykanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);          
            if (result == DialogResult.Yes) this.Close();
        }

        private async void STOP_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.0", true);
        }

        private async void dzwonek_OFF_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.5", true);
        }

        private async void kasuj_alarmy_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.4", true);
            bool new_alarm = await PLC.readBool("DB8.DBX1.0");
            bool isconnect = false;

            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog = Mieszalnia; Integrated Security = true");
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

        private async void bez_blokad_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.2", true);
            tryb_pracy_panel.Height = 60;
        }

        private async void z_blokadami_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.1", true);
            tryb_pracy_panel.Height = 60;
        }

        private async Task dzwonek()
        {
            bool dzwonek = await PLC.readBool("DB8.DBX6.5");
            if (dzwonek == true)
            {
                dzwonek_image.Visible = true;
            }
            else
            {
                dzwonek_image.Visible = false;
            }
        }

        private async Task opr_dr_tech()
        {
            bool opr_dr_tech = await PLC.readBool("DB8.DBX6.3");
            if (opr_dr_tech == true)
            {
                opr_dr_tech_label.Enabled = true;
            }
            else
            {
                opr_dr_tech_label.Enabled = false;
            }
        }

        private async Task auto()
        {
            bool auto = await PLC.readBool("DB8.DBX6.1");
            if (auto == true)
            {
                z_blokadami_label.Visible = true;
                bez_blokad_label.Visible = false;
            }
            else
            {
                z_blokadami_label.Visible = false;
                bez_blokad_label.Visible = true;
            }
        }
        
        private async Task alarm_obiekt()
        {
            bool alarm_obiekt = await PLC.readBool("DB8.DBX6.4");
            if (alarm_obiekt == true)
            {
                alarm_obiekt_box.Enabled = true;
            }
            else
            {
                alarm_obiekt_box.Enabled = false;
            }
        }

        private async Task zasuwa(string open, string close, string awaria, PictureBox name)
        {
            bool bit_open = await PLC.readBool(open);
            bool bit_close = await PLC.readBool(close);
            bool bit_awaria = await PLC.readBool(awaria);

            if (bit_open == true && bit_awaria == false)
            {
                name.Image = Properties.Resources.ZE_OPEN;
            }
            else if (bit_close == true && bit_awaria == false)
            {
                name.Image = Properties.Resources.ZE_CLOSE;
            }
            else if (bit_awaria == true)
            {
                name.Image = Properties.Resources.ZE_ALARM;
            }
            else
            {
                name.Image = Properties.Resources.ZE;
            }
        }

        private async Task wibro(string on, string awaria, PictureBox name)
        {
            bool bit_on = await PLC.readBool(on);
            bool bit_awaria = await PLC.readBool(awaria);

            if (bit_on == true && bit_awaria == false)
            {
                name.Image = Properties.Resources.silnik_2_praca;
            }
            else if (bit_awaria == true)
            {
                name.Image = Properties.Resources.silnik_2_alarm;
            }
            else
            {
                name.Image = Properties.Resources.silnik_2;
            }
        }

        private async Task screw(string on, string awaria, PictureBox name)
        {
            bool bit_on = await PLC.readBool(on);
            bool bit_awaria = await PLC.readBool(awaria);

            if (bit_on == true && bit_awaria == false)
            {
                name.Image = Properties.Resources.PSADM_G_pion;
            }            
            else
            {
                name.Image = Properties.Resources.NW_PSADM_pion;
            }
        }

        private async Task napelnienie(string zmienna, PictureBox name)
        {
            bool var = await PLC.readBool(zmienna);

            if (var == true)
            {
                name.Visible = true;
            }
            else
            {
                name.Visible = false;
            }
        }

        private async Task drogi(string zmienna, Label name)
        {
            bool var = await PLC.readBool(zmienna);

            if (var == true)
            {
                name.BackColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                name.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void tryb_pracy_button_Click(object sender, EventArgs e)
        {
            if (tryb_pracy_panel.Height == 60) tryb_pracy_panel.Height = 122;
            else tryb_pracy_panel.Height = 60;
        }

        private void ustawienia_button_Click(object sender, EventArgs e)
        {
            if (ustawienia_panel.Height == 60) ustawienia_panel.Height = 123;
            else ustawienia_panel.Height = 60;
        }

        private void alarmy_button_Click(object sender, EventArgs e)
        {
            if (alarmy_panel.Height == 60) alarmy_panel.Height = 124;
            else alarmy_panel.Height = 60;
        }

        private void uzytkownik_button_Click(object sender, EventArgs e)
        {
            if (uzytkownik_panel.Height == 60) uzytkownik_panel.Height = 123;
            else uzytkownik_panel.Height = 60;
        }

        private void pomoc_button_Click(object sender, EventArgs e)
        {
            if (pomoc_panel.Height == 60) pomoc_panel.Height = 123;
            else pomoc_panel.Height = 60;
        }

        private void parametry_podstawowe_button_Click(object sender, EventArgs e)
        {
            Parametry_podstawowe parametry_window = new Parametry_podstawowe();
            parametry_window.Show();
            ustawienia_panel.Height = 60;
        }

        private void serwis_button_Click(object sender, EventArgs e)
        {
            Serwis window = new Serwis();
            window.Show();            
            ustawienia_panel.Height = 60;
        }

        private void alarmy_aktywne_button_Click(object sender, EventArgs e)
        {
            Alarmy_aktywne alarmy_window = new Alarmy_aktywne();
            alarmy_window.Show();
            alarmy_panel.Height = 60;
        }

        private void alarmy_hist_button_Click(object sender, EventArgs e)
        {
            Alarmy_historyczne alarmy_window = new Alarmy_historyczne();
            alarmy_window.Show();
            alarmy_panel.Height = 60;
        }
       
        private void ZE1_Click(object sender, EventArgs e)
        {
            ze1 window = new ze1();
            window.Show();
        }
        private void ZE2_Click(object sender, EventArgs e)
        {
            ze2 window = new ze2();
            window.Show();
        }

        private void ZE3_Click(object sender, EventArgs e)
        {
            ze3 window = new ze3();
            window.Show();
        }

        private void z1_name_Click(object sender, EventArgs e)
        {
            Opisy_Z window = new Opisy_Z();
            window.Show();
        }

        private void z2_name_Click(object sender, EventArgs e)
        {
            Opisy_Z window = new Opisy_Z();
            window.Show();           
        }

        private void wyloguj_button_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            login_main win = new login_main();
            win.Show();
        }

        private void przelacz_user_button_Click(object sender, EventArgs e)
        {
            login_main win = new login_main();
            win.Show();
        }

        private void schemat_button_Click(object sender, EventArgs e)
        {
            Schemat win = new Schemat();
            win.Show();
            pomoc_panel.Height = 60;
        }

        private void instrukcja_button_Click(object sender, EventArgs e)
        {
            Instrukcja win = new Instrukcja();
            win.Show();
            pomoc_panel.Height = 60;
        }       

        private void auto1_button_Click(object sender, EventArgs e)
        {
            Auto1 auto1_window = new Auto1();
            auto1_window.Show();
            tryb_pracy_panel.Height = 60;
        }
        private void Wb1_Click(object sender, EventArgs e)
        {
            var window = new Wb1();
            window.Show();
        }

        private void Wb2_Click(object sender, EventArgs e)
        {
            var window = new Wb2();
            window.Show();
        }     

        private void Wb3_Click(object sender, EventArgs e)
        {
            var window = new Wb3();
            window.Show();
        }

        private async void recipe_button_Click(object sender, EventArgs e)
        {
            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog = Mieszalnia; Integrated Security = true");
            try
            {
                await conn.OpenAsync();
                var window = new Windows.Recipes.Main(conn, this);
                window.Show();
            }
            catch
            {
                conn.Dispose();
                MessageBox.Show("Brak połączenia z bazą danych.", "Błąd");
            }
        }

        private async Task read_weight_SV(int variable, Label label)
        {
            var weight_SV = Convert.ToDouble(await PLC.analog_read(20, variable, S7.Net.VarType.Real));

            if (weight_SV > 0)
            {
                label.Visible = true;
                label.Text = $"{weight_SV.ToString("0.##")} kg";
            }
            else label.Visible = false;
        }

        private async Task status_line()
        {
            var status_var = Convert.ToInt16(await PLC.analog_read(20, 28, S7.Net.VarType.Int));

            switch (status_var)
            {
                case 0:
                    status_auto_label.Text = "Zatrzymana";
                    break;
                case 1:
                    status_auto_label.Text = "Naważanie składnika nr.1 (z zbiornika Z1)";
                    break;
                case 2:
                    status_auto_label.Text = "Naważanie składnika nr.2 (z zbiornika Z2)";
                    break;
                case 3:
                    status_auto_label.Text = "Mieszanie...";
                    break;
                case 4:
                    status_auto_label.Text = "Wysyp mieszanki z wagi W1";
                    break;
            }
        }

        private async void start_autorecipe_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB20.DBX32.2", true);
        }

        private async void stop_autorecipe_button_ClickAsync(object sender, EventArgs e)
        {
            await PLC.writeBool("DB20.DBX32.3", true);
        }        

        private async Task time_mieszania()
        {
            var time = Convert.ToInt32(await PLC.analog_read(10, 4, S7.Net.VarType.Int));

            if (time > 0)
            {
                t_mieszania_label.Visible = true;
                t_mieszania_elapsed_label.Visible = true;

                t_mieszania_elapsed_label.Text = $"{time} s";
            }
            else
            {
                t_mieszania_label.Visible = false;
                t_mieszania_elapsed_label.Visible = false;
            }
        }

        private void Mi1_Click(object sender, EventArgs e)
        {
            var window = new Mi1();
            window.Show();
        }
    }
}
