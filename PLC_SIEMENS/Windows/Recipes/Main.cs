using PLC_SIEMENS.Definitions;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Recipes
{
    public partial class Main : Form
    {
        private readonly SqlConnection conn;
        private readonly PLC_SIEMENS.Main MainApp;
        public Main(SqlConnection connection, PLC_SIEMENS.Main main)
        {
            InitializeComponent();
            main_timer.Start();
            MainApp = main;
            conn = connection;
            SqlCommand SHOW_first_recipe = new SqlCommand("SELECT TOP 1 * FROM Recipes ORDER BY ID", conn);
            SqlCommand SHOW_record_count = new SqlCommand("SELECT COUNT(id) FROM Recipes", conn);

            SqlDataReader first_recipe = SHOW_first_recipe.ExecuteReader();
            using (first_recipe)
            {
                while (first_recipe.Read())
                {
                    id_box.Text = first_recipe.GetValue(0).ToString();
                    miesz_name.Text = first_recipe.GetString(1);
                    skladnik1_name.Text = first_recipe.GetString(2);
                    skladnik2_name.Text = first_recipe.GetString(3);
                    skladnik1_zawartosc.Text = first_recipe.GetValue(4).ToString();
                    skladnik2_zawartosc.Text = first_recipe.GetValue(5).ToString();
                    rekord_box.Text = "1";
                }
            }
            SqlDataReader record_count = SHOW_record_count.ExecuteReader();
            using (record_count)
            {
                while (record_count.Read()) rekord_count_textbox.Text = record_count.GetInt32(0).ToString();              
            }

            //Wpisanie nazw silosów 
            string filepath = "OpisyZ.txt";
            string[] name = new string[2];
            name = File.ReadAllLines(filepath).ToArray();
            Z1_name_textBox.Text = name[0];
            Z2_name_textBox.Text = name[1];

            init();
        }

        private async void init()
        {
            var cykle_sv = Convert.ToInt32(await PLC.analog_read(20, 2, S7.Net.VarType.Int));
            cykle_SV_textBox.Text = cykle_sv.ToString();
            var wsad_sv = Convert.ToDouble(await PLC.analog_read(20, 4, S7.Net.VarType.Real));
            waga_SV_textBox.Text = wsad_sv.ToString();
        }

        private void add_recipe_Click(object sender, EventArgs e)
        {
            var window = new Add_recipe(conn, this);            
            window.Show();
        }

        public void first_recipe_button_Click(object sender, EventArgs e)
        {           
            SqlCommand SHOW_first_recipe = new SqlCommand("SELECT TOP 1 * FROM Recipes ORDER BY ID", conn);
            SqlDataReader first_recipe = SHOW_first_recipe.ExecuteReader();
            using (first_recipe)
            {
                while (first_recipe.Read())
                {
                    id_box.Text = first_recipe.GetValue(0).ToString();
                    miesz_name.Text = first_recipe.GetString(1);
                    skladnik1_name.Text = first_recipe.GetString(2);
                    skladnik2_name.Text = first_recipe.GetString(3);
                    skladnik1_zawartosc.Text = first_recipe.GetValue(4).ToString();
                    skladnik2_zawartosc.Text = first_recipe.GetValue(5).ToString();
                    rekord_box.Text = "1";
                }
            }
        }

        public void last_recipe_button_Click(object sender, EventArgs e)
        {
            SqlCommand SHOW_last_record = new SqlCommand("SELECT COUNT(DISTINCT ID) FROM Recipes", conn);
            SqlCommand SHOW_last_recipe = new SqlCommand("SELECT DISTINCT TOP 1 * FROM Recipes ORDER BY ID DESC", conn);

            SqlDataReader last_record = SHOW_last_record.ExecuteReader();
            using (last_record)
            {
                while (last_record.Read())
                {
                    int record = (int)last_record.GetValue(0);

                    rekord_box.Text = record.ToString();
                }
            }

            SqlDataReader last_recipe = SHOW_last_recipe.ExecuteReader();
            using (last_recipe)
            {
                while (last_recipe.Read())
                {
                    id_box.Text = last_recipe.GetValue(0).ToString();
                    miesz_name.Text = last_recipe.GetString(1);
                    skladnik1_name.Text = last_recipe.GetString(2);
                    skladnik2_name.Text = last_recipe.GetString(3);
                    skladnik1_zawartosc.Text = last_recipe.GetValue(4).ToString();
                    skladnik2_zawartosc.Text = last_recipe.GetValue(5).ToString();
                }
            }                
        }

        public void next_recipe_Click(object sender, EventArgs e)
        {            
            int rekord = int.Parse(rekord_box.Text);
            int new_rekord = rekord + 1;
                
            SqlCommand SHOW_next_recipe = new SqlCommand($"SELECT * FROM (SELECT *,row_number() over (order by ID) AS rn FROM Recipes)S where rn ={new_rekord}", conn);
            SqlDataReader next_recipe = SHOW_next_recipe.ExecuteReader();

            using (next_recipe)
            {
                while (next_recipe.Read())
                {
                    id_box.Text = next_recipe.GetValue(0).ToString();
                    miesz_name.Text = next_recipe.GetString(1);
                    skladnik1_name.Text = next_recipe.GetString(2);
                    skladnik2_name.Text = next_recipe.GetString(3);
                    skladnik1_zawartosc.Text = next_recipe.GetValue(4).ToString();
                    skladnik2_zawartosc.Text = next_recipe.GetValue(5).ToString();
                    rekord_box.Text = new_rekord.ToString();
                }
            }          
        }

        private void previous_recipe_button_Click(object sender, EventArgs e)
        {
            int rekord = int.Parse(rekord_box.Text);
            int new_rekord = rekord - 1;

            //MySqlCommand SHOW_previous_recipe = new MySqlCommand("SELECT * FROM mieszanka WHERE ID =" + new_id, conn);
            SqlCommand SHOW_previous_recipe = new SqlCommand($"SELECT * FROM (SELECT *,row_number() over (order by ID) AS rn FROM Recipes)S where rn ={new_rekord}", conn);
            SqlDataReader previous_recipe = SHOW_previous_recipe.ExecuteReader();
            using (previous_recipe)
            {
                while (previous_recipe.Read())
                {
                    id_box.Text = previous_recipe.GetValue(0).ToString();
                    miesz_name.Text = previous_recipe.GetString(1);
                    skladnik1_name.Text = previous_recipe.GetString(2);
                    skladnik2_name.Text = previous_recipe.GetString(3);
                    skladnik1_zawartosc.Text = previous_recipe.GetValue(4).ToString();
                    skladnik2_zawartosc.Text = previous_recipe.GetValue(5).ToString();
                    rekord_box.Text = new_rekord.ToString();
                }
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            int id = int.Parse(id_box.Text);
            string mieszanka_name = miesz_name.Text;

            SqlCommand delete_recipe = new SqlCommand("DELETE from Recipes where id =" + id, conn);

            DialogResult result = MessageBox.Show("Czy napewno chcesz usunąć recepture o nazwie " + mieszanka_name + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                if (delete_recipe.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Pomyślnie usunięto recepture.", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlCommand SHOW_last_recipe = new SqlCommand("SELECT TOP 1 * FROM Recipes ORDER BY ID DESC", conn);

                    SqlDataReader last_recipe = SHOW_last_recipe.ExecuteReader();
                    using (last_recipe)
                    {
                        if (last_recipe.Read() == false)
                        {
                            id_box.Text = " ";
                            miesz_name.Text = " ";
                            skladnik1_name.Text = " ";
                            skladnik2_name.Text = " ";
                            skladnik1_zawartosc.Text = " ";
                            skladnik2_zawartosc.Text = " ";
                            rekord_box.Text = " ";
                        }
                        else
                        {
                            id_box.Text = last_recipe.GetValue(0).ToString();
                            miesz_name.Text = last_recipe.GetString(1);
                            skladnik1_name.Text = last_recipe.GetString(2);
                            skladnik2_name.Text = last_recipe.GetString(3);
                            skladnik1_zawartosc.Text = last_recipe.GetValue(4).ToString();
                            skladnik2_zawartosc.Text = last_recipe.GetValue(5).ToString();
                        }
                    }                   
                }
            }
        }

        private void modify_button_Click(object sender, EventArgs e)
        {
            Modify_recipe modify_window = new Modify_recipe(conn, this);

            int id = int.Parse(id_box.Text);
            SqlCommand SHOW_current_recipe = new SqlCommand("SELECT * FROM Recipes WHERE ID=" + id, conn);
            SqlDataReader current_recipe = SHOW_current_recipe.ExecuteReader();

            using (current_recipe)
            {
                while (current_recipe.Read())
                {
                    modify_window.id_box.Text = current_recipe.GetValue(0).ToString();
                    modify_window.mieszanka_name.Text = current_recipe.GetString(1);
                    modify_window.skl1_name.Text = current_recipe.GetString(2);
                    modify_window.skl2_name.Text = current_recipe.GetString(3);
                    modify_window.skl1_zaw.Text = current_recipe.GetValue(4).ToString();
                    modify_window.skl2_zaw.Text = current_recipe.GetValue(5).ToString();
                }
            }          
            modify_window.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private async void loadPLC_button_Click(object sender, EventArgs e)
        {
            if (cykle_SV_textBox.Text != string.Empty & waga_SV_textBox.Text != string.Empty)
            {
                await PLC.analog_write("DB20.DBW2", short.Parse(cykle_SV_textBox.Text));
                await PLC.analog_write("DB20.DBD4", float.Parse(waga_SV_textBox.Text));
                await PLC.analog_write("DB20.DBD8", float.Parse(skl1_waga_textbox.Text));
                await PLC.analog_write("DB20.DBD12", float.Parse(skl2_waga_textbox.Text));
                await PLC.analog_write("DB20.DBW38", short.Parse(id_box.Text));

                MainApp.cykle_SV_label.Text = cykle_SV_textBox.Text;
                MainApp.weight_SV_label.Text = waga_SV_textBox.Text;
                MainApp.recipe_name_label.Text = miesz_name.Text;

                MessageBox.Show("Pomyślnie załadowano wartości do sterownika.", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Błąd podczas ładowania. Uzupełnij zadany wsad wagi oraz cykle lub sprawdź poprawność zapisu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

        private async void main_timer_Tick(object sender, EventArgs e)
        {
            if (waga_SV_textBox.Text != string.Empty)
            {
                double skl1_weight = CalculateWeight(int.Parse(skladnik1_zawartosc.Text));
                double skl2_weight = CalculateWeight(int.Parse(skladnik2_zawartosc.Text));
                skl1_waga_textbox.Text = skl1_weight.ToString();
                skl2_waga_textbox.Text = skl2_weight.ToString();
            }

            bool recipe_on = await PLC.readBool("DB20.DBX32.1");

            if (recipe_on)
            {
                recipe_on_label.Visible = true;
                loadPLC_button.Visible = false;
            }
            else
            {
                recipe_on_label.Visible = false;
                loadPLC_button.Visible = true;
            }              
        }

        private double CalculateWeight(int procent)
        {
            try
            {
                double procent_double = procent / 100;
                double weightAll = double.Parse(waga_SV_textBox.Text);

                double weightElement = (weightAll * procent)/100;
                return weightElement;
            }
            catch { return 0; }
        }
    }
}
