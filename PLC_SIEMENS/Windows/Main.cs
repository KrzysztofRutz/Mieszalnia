using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC_SIEMENS.Definitions;

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
        }

        public async void main_timer_Tick(object sender, EventArgs e)
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

        private void program_cycle_Tick(object sender, EventArgs e)
        {
            if (PLC.plc.IsConnected)
            {
                dzwonek();
                opr_dr_tech();
                auto();
                alarm_obiekt();               
                //analog_read(40, p1_prad_text, "A");
                //analog_write(18, r1_predkosc_text, "%");
                napelnienie("DB6.DBX4.0", Z1_pelny);
                napelnienie("DB6.DBX4.1", Z2_pelny);
                //redler("DB6.DBX0.0", "DB6.DBX0.1", R1);
                //zasuwa("DB6.DBX40.0", "DB6.DBX40.1", "DB6.DBX40.2", ZE1);
                //zasuwa("DB6.DBX40.3", "DB6.DBX40.4", "DB6.DBX40.5", ZE2);
                zasuwa("DB6.DBX2.6", "DB6.DBX2.7", "DB6.DBX3.0", ZE3);
                kontrola_off("DB8.DBX4.6", kontrola_blokadasoft_OFF_label);
                kontrola_off("DB8.DBX4.7", kontrola_prad_OFF_label);
                kontrola_off("DB8.DBX5.0", kontrola_obroty_OFF_label);
                kontrola_off("DB8.DBX5.1", kontrola_pas_OFF_label);
            }            
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

        private async void dzwonek()
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

        private async void opr_dr_tech()
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

        private async void auto()
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

        private async void kontrola_off(string zmienna, System.Windows.Forms.TextBox label)
        {
            bool kontrola_off = await PLC.readBool(zmienna);
            if (kontrola_off == true)
            {
                label.Visible = true;
            }
            else
            {
                label.Visible = false;
            }
        }
        
        private async void alarm_obiekt()
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

        private void tryb_pracy_button_Click(object sender, EventArgs e)
        {
            if (tryb_pracy_panel.Height == 60)
            {
                tryb_pracy_panel.Height = 216;
            }
            else
            {
                tryb_pracy_panel.Height = 60;
            }
        }

        private void ustawienia_button_Click(object sender, EventArgs e)
        {
            if (ustawienia_panel.Height == 60)
            {
                ustawienia_panel.Height = 123;
            }
            else
            {
                ustawienia_panel.Height = 60;
            }
        }

        private void alarmy_button_Click(object sender, EventArgs e)
        {
            if (alarmy_panel.Height == 60)
            {
                alarmy_panel.Height = 184;
            }
            else
            {
                alarmy_panel.Height = 60;
            }
        }

        private void uzytkownik_button_Click(object sender, EventArgs e)
        {
            if (uzytkownik_panel.Height == 60)
            {
                uzytkownik_panel.Height = 123;
            }
            else
            {
                uzytkownik_panel.Height = 60;
            }
        }

        private void pomoc_button_Click(object sender, EventArgs e)
        {
            if (pomoc_panel.Height == 60)
            {
                pomoc_panel.Height = 123;
            }
            else
            {
                pomoc_panel.Height = 60;
            }
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

        private async void zasuwa(string open, string close, string awaria, PictureBox name)
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

        private async void redler(string on, string awaria, System.Windows.Forms.Label name)
        {
            bool bit_on = await PLC.readBool(on);
            bool bit_awaria = await PLC.readBool(awaria);

            if (bit_on == true && bit_awaria == false)
            {
                name.BackColor = Color.Green;
            }
            else if (bit_awaria == true)
            {
                name.BackColor = Color.Red;
            }
            else
            {
                name.BackColor = Color.Silver;
            }
        }

        private async void napelnienie(string zmienna, PictureBox name)
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

        private void ZE1_Click(object sender, EventArgs e)
        {
            ze1 window = new ze1();
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

        private void R1_Click(object sender, EventArgs e)
        {
            R1 window = new R1();
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

        private void auto1_button_Click(object sender, EventArgs e)
        {
            Auto1 auto1_window = new Auto1();
            auto1_window.Show();
            tryb_pracy_panel.Height = 60;
        }
    }
}
