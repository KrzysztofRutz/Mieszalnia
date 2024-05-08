using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC_SIEMENS.Definitions;
using PLC_SIEMENS.Windows.Devices;

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
            Z1_name_textbox.Text = name[0];
            Z2_name_textbox.Text = name[1];

            //Załączenie tickerów odczytu danych w czasie rzeczywistym
            main_timer.Start();
            program_cycle.Start();

            init();
        }
      
        private async void init()
        {
            var cykle_sv = Convert.ToInt32(await PLC.analog_read(20, 2, S7.Net.VarType.Int));
            cyclesSV_label.Text = cykle_sv.ToString();
            var wsad_sv = Convert.ToDouble(await PLC.analog_read(20, 4, S7.Net.VarType.Real));
            weightSV_label.Text = wsad_sv.ToString();
            var cykle_pv = Convert.ToInt32(await PLC.analog_read(20, 0, S7.Net.VarType.Int));
            cyclesPV_label.Text = cykle_pv.ToString();
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
                        RecipeName_label.Text = reader.GetString(0);
                    }
                }
                conn.Close();
            }
        }
        private async void main_timer_Tick(object sender, EventArgs e)
        {
            //Odświeżanie daty i godziny na wizualizacji 
            ActualTime_textbox.Text = DateTime.Now.ToLongTimeString();
            ActualDate_textbox.Text = DateTime.Now.ToLongDateString();

            //Jeśli wystąpił nowy alarm to wykonujemy funkcje dodania go do bazy 
            if (await PLC.readBool("DB8.DBX1.0")) await ActiveAlarm.Detect();
        }
      
        private async void program_cycle_Tick(object sender, EventArgs e)
        {
            if (PLC.plc.IsConnected)
            {
                await Bell();
                await Auto();
                await AlarmObject();
                await StatusLine();
                await Permissions();
                await StatusAutoRecipe();

                await ReadWeightSV(8, Z1_weightSV_label);
                await ReadWeightSV(12, Z2_weightSV_label);

                var cykle_PV = Convert.ToDouble(await PLC.analog_read(20, 0, S7.Net.VarType.Int));
                cyclesPV_label.Text = cykle_PV.ToString();
                var weight = Convert.ToDouble(await PLC.analog_read(10, 0, S7.Net.VarType.Real));
                Weight_label.Text = $"{weight.ToString("0.##")} kg";
                var weight_skl = Convert.ToDouble(await PLC.analog_read(20, 34, S7.Net.VarType.Real));
                IngredientWeightPV_label.Text = $"{weight_skl.ToString("0.##")} kg";
                var weight_PV = Convert.ToDouble(await PLC.analog_read(20, 24, S7.Net.VarType.Real));
                weightPV_label.Text = $"{weight_PV.ToString("0.##")} kg";
                var mieszanki_counter = Convert.ToDouble(await PLC.analog_read(20, 30, S7.Net.VarType.Int));
                MixturesCounter_label.Text = mieszanki_counter.ToString();

                await MixerTime();
                await LockTime(6, ze1_lock_label, ze1_lock_elapsed_label);
                await LockTime(8, ze2_lock_label, ze2_lock_elapsed_label);
                await LockTime(10, ze3_lock_label, ze3_lock_elapsed_label);

                await EmptyInfoVisible("DB8.DBX2.0", Z1_emptyInfo_panel);
                await EmptyInfoVisible("DB8.DBX2.1", Z2_emptyInfo_panel);

                await EmptySilo("DB6.DBX4.0", Z1_empty_picturebox);
                await EmptySilo("DB6.DBX4.1", Z2_empty_picturebox);

                await Screw("DB6.DBX0.0", "DB6.DBX0.1", Mi1_picturebox);
                await VibroMotor("DB6.DBX0.2", "DB6.DBX0.3", Wb1);
                await VibroMotor("DB6.DBX0.4", "DB6.DBX0.5", Wb2);
                await VibroMotor("DB6.DBX0.6", "DB6.DBX0.7", Wb3);

                await Slide("DB6.DBX2.0", "DB6.DBX2.1", "DB6.DBX2.2", ZE1_picturebox);
                await Slide("DB6.DBX2.3", "DB6.DBX2.4", "DB6.DBX2.5", ZE2_picturebox);
                await Slide("DB6.DBX2.6", "DB6.DBX2.7", "DB6.DBX3.0", ZE3_picturebox);

                await Roads("DB5.DBX0.0", odc1_label1);
                await Roads("DB5.DBX0.0", odc1_label2);
                await Roads("DB5.DBX0.0", odc1_label3);
                await Roads("DB5.DBX0.1", odc2_label1);
                await Roads("DB5.DBX0.1", odc2_label2);
                await Roads("DB5.DBX0.1", odc2_label3);
                await Roads("DB5.DBX0.2", odc3_label);
            }
            else await PLC.connect();
        }

        private void close_app_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy napewno chcesz wyjść z aplikacji?", "Zamykanie aplikacji", MessageBoxButtons.YesNo, MessageBoxIcon.Question);          
            if (result == DialogResult.Yes) Close();
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

            await ActiveAlarm.Delete();           
        }

        private async void bez_blokad_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.2", true);
            WorkMode_panel.Height = 60;
        }

        private async void z_blokadami_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX0.1", true);
            WorkMode_panel.Height = 60;
        }

        private async Task Bell()
        {
            bool dzwonek = await PLC.readBool("DB8.DBX6.5");
            if (dzwonek == true)
            {
                Bell_picturebox.Visible = true;
            }
            else
            {
                Bell_picturebox.Visible = false;
            }
        }

        private async Task Auto()
        {
            bool auto = await PLC.readBool("DB8.DBX6.1");
            if (auto == true)
            {
                AutoWork_label.Visible = true;
                HandWork_label.Visible = false;
            }
            else
            {
                AutoWork_label.Visible = false;
                HandWork_label.Visible = true;
            }
        }
        
        private async Task AlarmObject()
        {
            bool alarm_obiekt = await PLC.readBool("DB8.DBX6.4");
            if (alarm_obiekt == true)
            {
                AlarmObject_textbox.Enabled = true;
            }
            else
            {
                AlarmObject_textbox.Enabled = false;
            }
        }

        private async Task Slide(string open, string close, string alarm, PictureBox pictureBox)
        {
            bool bit_open = await PLC.readBool(open);
            bool bit_close = await PLC.readBool(close);
            bool bit_alarm = await PLC.readBool(alarm);

            if (bit_open == true && bit_alarm == false)
            {
                pictureBox.Image = Properties.Resources.ZE_OPEN;
            }
            else if (bit_close == true && bit_alarm == false)
            {
                pictureBox.Image = Properties.Resources.ZE_CLOSE;
            }
            else if (bit_alarm)
            {
                pictureBox.Image = Properties.Resources.ZE_ALARM;
            }
            else
            {
                pictureBox.Image = Properties.Resources.ZE;
            }
        }

        private async Task VibroMotor(string on, string alarm, PictureBox pictureBox)
        {
            bool bit_on = await PLC.readBool(on);
            bool bit_alarm = await PLC.readBool(alarm);

            if (bit_on == true && bit_alarm == false)
            {
                pictureBox.Image = Properties.Resources.silnik_2_praca;
            }
            else if (bit_alarm == true)
            {
                pictureBox.Image = Properties.Resources.silnik_2_alarm;
            }
            else
            {
                pictureBox.Image = Properties.Resources.silnik_2;
            }
        }

        private async Task Screw(string on, string awaria, PictureBox name)
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

        private async Task EmptySilo(string variable, PictureBox pictureBox)
        {
            bool empty = await PLC.readBool(variable);

            if (!empty) pictureBox.Visible = true;
            else pictureBox.Visible = false;
        }

        private async Task Roads(string zmienna, Label name)
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
            if (WorkMode_panel.Height == 60) WorkMode_panel.Height = 122;
            else WorkMode_panel.Height = 60;
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

        private async Task ReadWeightSV(int variable, Label label)
        {
            var weight_SV = Convert.ToDouble(await PLC.analog_read(20, variable, S7.Net.VarType.Real));

            if (weight_SV > 0)
            {
                label.Visible = true;
                label.Text = $"{weight_SV.ToString("0.##")} kg";
            }
            else label.Visible = false;
        }

        private async Task StatusLine()
        {
            var status_var = Convert.ToInt16(await PLC.analog_read(20, 28, S7.Net.VarType.Int));

            switch (status_var)
            {
                case 0:
                    StatusAutoLine_label.Text = "Zatrzymana";
                    break;
                case 1:
                    StatusAutoLine_label.Text = "Naważanie składnika nr.1 (z zbiornika Z1)";
                    break;
                case 2:
                    StatusAutoLine_label.Text = "Naważanie składnika nr.2 (z zbiornika Z2)";
                    break;
                case 3:
                    StatusAutoLine_label.Text = "Mieszanie...";
                    break;
                case 4:
                    StatusAutoLine_label.Text = "Wysyp mieszanki z wagi W1";
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

        private async Task MixerTime()
        {
            var time = Convert.ToInt32(await PLC.analog_read(10, 4, S7.Net.VarType.Int));

            if (time > 0)
            {
                t_mixer_label.Visible = true;
                t_mixer_elapsed_label.Visible = true;

                t_mixer_elapsed_label.Text = $"{time} s";
            }
            else
            {
                t_mixer_label.Visible = false;
                t_mixer_elapsed_label.Visible = false;
            }
        }

        private void Mi1_Click(object sender, EventArgs e)
        {
            var window = new Mi1();
            window.Show();
        }

        private async Task Permissions()
        {
            bool permission = await PLC.readBool("DB20.DBX32.0");
            if (permission)
            {
                permission_label.Text = "Zezwolono na uruchomienie";
                permission_label.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                permission_label.Text = "Brak zezwolenia na uruchomienie";
                permission_label.ForeColor = System.Drawing.Color.Red;
            }
        }
        private async Task StatusAutoRecipe()
        {
            bool work = await PLC.readBool("DB20.DBX32.1");
            if (work) work_label.Text = "Pracuje";
            else work_label.Text = "Zatrzymana";
        }
        private async Task LockTime(int variable, Label label, Label elapsed_label)
        {
            var time = Convert.ToInt32(await PLC.analog_read(10, variable, S7.Net.VarType.Int));

            if (time > 0)
            {
                label.Visible = true;
                elapsed_label.Visible = true;

                elapsed_label.Text = $"{time} s";
            }
            else
            {
                label.Visible = false;
                elapsed_label.Visible = false;
            }
        }
        private async Task EmptyInfoVisible(string variable, Panel panel)
        {
            var empty = await PLC.readBool(variable);

            if (empty) panel.Visible = true;
            else panel.Visible = false;
        }

        private async void Z1_emptyInfo_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX4.0", true);
        }

        private async void Z2_emptyInfo_button_Click(object sender, EventArgs e)
        {
            await PLC.writeBool("DB8.DBX4.1", true);
        }
    }
}
