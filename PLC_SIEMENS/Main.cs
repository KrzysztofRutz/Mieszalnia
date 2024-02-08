using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using S7.Net;



namespace PLC_SIEMENS
{
    public partial class Main : PLC
    {
        public static Main instance;
        public System.Windows.Forms.TextBox z1_l;
        
        public Main()
        {
            InitializeComponent();
            instance = this;

            //login_main window = new login_main();
            //window.Show();

            string filepath = "OpisyZ.txt";
            string[] name = new string[2];
            name = File.ReadAllLines(filepath).ToArray();
            z1_name.Text = name[0];
            z2_name.Text = name[1];
           

            main_timer.Start();
            program_cycle.Start();
            
            /*plc = new Plc(CpuType.S71200, "192.168.0.201", 0, 0);
           
            plc.Open();
            connected = plc.IsConnected;
            if (connected == true)
            {
                connect_text.Text = "Połączono ze sterownikiem PLC.";
            }
            else
            {
                connect_text.Text = "Brak połączenia ze sterownikiem PLC.";
                connect_text.ForeColor = Color.Red;
            }*/

        }


        public void main_timer_Tick(object sender, EventArgs e)
        {
           
            actual_time.Text = DateTime.Now.ToLongTimeString();
            actual_date.Text = DateTime.Now.ToLongDateString();

            int i = 0;           
            int row;
            Microsoft.Office.Interop.Excel.Application App;
            Workbook book;
            Worksheet sheet;
            Range range;


            string file = "C:\\Users\\krzys\\OneDrive\\Pulpit\\UMG\\_Praca inżynierska\\SCADA\\PLC_SIEMENS\\PLC_SIEMENS\\Alarmy.xlsx";

            string filepath1 = "alarm_his_date.txt";
            string filepath2 = "alarm_his_text.txt";


            //bool new_alarm = (bool)plc.Read("DB8.DBX1.0");
            bool new_alarm = read_bool("DB8.DBX1.0");
            if (new_alarm == true)
            {
                if (file != string.Empty)
                {
                    App = new Microsoft.Office.Interop.Excel.Application();
                    book = App.Workbooks.Open(file);
                    sheet = book.Worksheets["Alarmy"];
                    range = sheet.UsedRange;

                    StreamWriter sw1 = File.AppendText(filepath1);
                    StreamWriter sw2 = File.AppendText(filepath2);

                    for (row = 2; row <= range.Rows.Count; row++)
                    {

                        string zmienna = range.Cells[row, 2].Text;
                        bool j = (bool)plc.Read(zmienna);
                        if (j == true)
                        {

                            string data = DateTime.Now.ToString("yyyy.MM.dd HH:mm");
                            //string czas = DateTime.Now.ToLongTimeString();
                            //string alarm_date = data + " " + czas;
                            string alarm_date = data;
                            string column = "D" + row;
                            Range cellRange = sheet.Range[column, column];
                            cellRange.Value = null;

                            cellRange.Value = alarm_date;
                            
                            //sw1.NewLine = alarm_date;
                            //sw2.NewLine = range.Cells[row, 3].Text;
                            sw1.WriteLine(alarm_date);
                            sw2.WriteLine(range.Cells[row, 3].Text);
                            
                                                      
                            book.Save();                                                       
                            //Alarmy_historyczne.instance.alarmyhis_grid.Rows.Add(range.Cells[row, 4].Text, range.Cells[row, 3].Text);
                        }
                        else
                        {
                            i++;
                        }                       
                    }
                    sw1.Close();
                    sw2.Close();
                    book.Close();
                    App.Quit();

                    //plc.Write("DB8.DBX0.7", true);
                    write_bool("DB8.DBX0.7");                                      
                }
            }
            else
            {
                i++;
            }
        }




        private void program_cycle_Tick(object sender, EventArgs e)
        {
            if (isconnected == true)
            {
                dzwonek();
                opr_dr_tech();
                auto();
                alarm_obiekt();
                zezwolenie_na_lokalne();
                //analog_read(40, p1_prad_text, "A");
                //analog_write(18, r1_predkosc_text, "%");
                napelnienie("DB6.DBX4.0", Z1_pelny);
                napelnienie("DB6.DBX4.1", Z2_pelny);
                //redler("DB6.DBX0.0", "DB6.DBX0.1", R1);
                //zasuwa("DB6.DBX40.0", "DB6.DBX40.1", "DB6.DBX40.2", ZE1);
                //zasuwa("DB6.DBX40.3", "DB6.DBX40.4", "DB6.DBX40.5", ZE2);
                //zasuwa("DB6.DBX40.6", "DB6.DBX40.7", "DB6.DBX41.0", ZE3);
                kontrola_off("DB8.DBX4.6", kontrola_blokadasoft_OFF_label);
                kontrola_off("DB8.DBX4.7", kontrola_prad_OFF_label);
                kontrola_off("DB8.DBX5.0", kontrola_obroty_OFF_label);
                kontrola_off("DB8.DBX5.1", kontrola_pas_OFF_label);
            }           
            //if (plc.IsConnected == false)
            //{
            //    plc_error_label.Visible = true;
            //}
            //else
            //    plc_error_label.Visible = false;
            //}

        }

       
        private void close_app_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void STOP_button_Click(object sender, EventArgs e)
        {
            //plc.Write("DB8.DBX0.0", true);
            write_bool("DB8.DBX0.0");
        }

        private void dzwonek_OFF_button_Click(object sender, EventArgs e)
        {
            //plc.Write("DB8.DBX0.5", true);
            write_bool("DB8.DBX0.5");
        }

        private void kasuj_alarmy_button_Click(object sender, EventArgs e)
        {
            //plc.Write("DB8.DBX0.4", true);
            write_bool("DB8.DBX0.4");
        }

        private void bez_blokad_button_Click(object sender, EventArgs e)
        {
            //plc.Write("DB8.DBX0.2", true);
            write_bool("DB8.DBX0.2");
            tryb_pracy_panel.Height = 60;
        }

        private void z_blokadami_button_Click(object sender, EventArgs e)
        {
            //plc.Write("DB8.DBX0.1", true);
            write_bool("DB8.DBX0.1");
            tryb_pracy_panel.Height = 60;
        }

        private void dzwonek()
        {
            //bool dzwonek = (bool)plc.Read("DB8.DBX6.5");
            bool dzwonek = read_bool("DB8.DBX6.5");
            if (dzwonek == true)
            {
                dzwonek_image.Visible = true;
            }
            else
            {
                dzwonek_image.Visible = false;
            }
        }

        private void opr_dr_tech()
        {
            //bool opr_dr_tech = (bool)plc.Read("DB8.DBX6.3");
            bool opr_dr_tech = read_bool("DB8.DBX6.3");
            if (opr_dr_tech == true)
            {
                opr_dr_tech_label.Enabled = true;
            }
            else
            {
                opr_dr_tech_label.Enabled = false;
            }
        }

        private void auto()
        {
            //bool auto = (bool)plc.Read("DB8.DBX6.1");
            bool auto = read_bool("DB8.DBX6.1");
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

        private void kontrola_off(string zmienna, System.Windows.Forms.TextBox label)
        {
            //bool kontrola_off = (bool)plc.Read(zmienna);
            bool kontrola_off = read_bool(zmienna);
            if (kontrola_off == true)
            {
                label.Visible = true;
            }
            else
            {
                label.Visible = false;
            }
        }

        private void analog_read(int zmienna, System.Windows.Forms.Label odczyt, string unit)
        {
            double var = Convert.ToDouble(plc.Read(DataType.DataBlock, 10, zmienna, VarType.Real, 1));
            odczyt.Text = var.ToString("0.##") + " " + unit;
        }

        private void analog_write(int zmienna, System.Windows.Forms.Label odczyt, string unit)
        {
            short analog = Convert.ToInt16(plc.Read(DataType.DataBlock, 11, zmienna, VarType.Int, 1));
            double label = (Convert.ToDouble(analog / 276.48));
            odczyt.Text = label.ToString("0.##") + " " + unit;
        }

        private void alarm_obiekt()
        {
            //bool alarm_obiekt = (bool)plc.Read("DB8.DBX6.4");
            bool alarm_obiekt = read_bool("DB8.DBX6.4");
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

        private void wykresy_button_Click(object sender, EventArgs e)
        {
            if (wykresy_panel.Height == 60)
            {
                wykresy_panel.Height = 216;
            }
            else
            {
                wykresy_panel.Height = 60;
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
            if (user_label.Text == "Serwis")
            {
                Serwis window = new Serwis();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
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

        public void zasuwa(string open, string close, string awaria, PictureBox name)
        {
            bool bit_open = (bool)plc.Read(open);
            bool bit_close = (bool)plc.Read(close);
            bool bit_awaria = (bool)plc.Read(awaria);

            if (bit_open == true && bit_awaria == false)
            {
                name.Image = PLC_SIEMENS.Properties.Resources.ZE_OPEN;
            }
            else if (bit_close == true && bit_awaria == false)
            {
                name.Image = PLC_SIEMENS.Properties.Resources.ZE_CLOSE;
            }
            else if (bit_awaria == true)
            {
                name.Image = PLC_SIEMENS.Properties.Resources.ZE_ALARM;
            }
            else
            {
                name.Image = PLC_SIEMENS.Properties.Resources.ZE;
            }
        }

        public void redler(string on, string awaria, System.Windows.Forms.Label name)
        {
            bool bit_on = (bool)plc.Read(on);
            bool bit_awaria = (bool)plc.Read(awaria);

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

        public void napelnienie(string zmienna, PictureBox name)
        {
            //bool var = (bool)plc.Read(zmienna);
            bool var = read_bool(zmienna);

            if (var == true)
            {
                name.Visible = true;
            }
            else
            {
                name.Visible = false;
            }
        }

        public void zezwolenie_na_lokalne()
        {
            //bool var = (bool)plc.Read("DB8.DBX8.2");
            bool var = read_bool("DB8.DBX8.2");

            if (var == true)
            {
                zezw_lok_label.Text = "Zezwolono";
                zezw_lok_label.ForeColor = Color.Red;
            }
            else
            {
                zezw_lok_label.Text = "Nie zezwolono";
                zezw_lok_label.ForeColor = Color.Black;
            }
        }

        private void ZE1_Click(object sender, EventArgs e)
        {
            ze1 window = new ze1();
            window.Show();
        }

        private void z1_name_Click(object sender, EventArgs e)
        {
            if (user_label.Text == "Kierownik")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
        }

        private void z2_name_Click(object sender, EventArgs e)
        {
            if (user_label.Text == "Kierownik")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
        }

        private void z3_name_Click(object sender, EventArgs e)
        {
            if (user_label.Text == "Kierownik")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
        }

        private void z4_name_Click(object sender, EventArgs e)
        {
            if (user_label.Text == "Kierownik")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
        }

        private void z5_name_Click(object sender, EventArgs e)
        {
            if (user_label.Text == "Kierownik")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
            }
            else
            {
                login window = new login();
                window.Show();
            }
        }

        private void z6_name_Click(object sender, EventArgs e)
        {
            login_main window = new login_main();
            window.Show();
        }

        private void R1_Click(object sender, EventArgs e)
        {
            R1 window = new R1();
            window.Show();
        }

        private void prady_button_Click(object sender, EventArgs e)
        {
            Wykresy wykresy_window = new Wykresy();
            wykresy_window.Show();
            wykresy_panel.Height = 60;
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

        private void AMR_button_Click(object sender, EventArgs e)
        {
            AMR win = new AMR();
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

        private void zezwolenie_lok_button_Click(object sender, EventArgs e)
        {
            Zezwolenie_na_lok win = new Zezwolenie_na_lok();
            win.Show();
            tryb_pracy_panel.Height = 60;
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

        private void ZE4_Click(object sender, EventArgs e)
        {
            ze4 window = new ze4();
            window.Show();
        }

        private void ZE5_Click(object sender, EventArgs e)
        {
            ze5 window = new ze5();
            window.Show();
        }

        private void ZE6_Click(object sender, EventArgs e)
        {
            ze6 window = new ze6();
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
