using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Recipes
{
    public partial class Add_recipe : Form
    {
        private readonly SqlConnection conn;
        private readonly Main MainWindow;
        public Add_recipe(SqlConnection connection, Main main_window)
        {
            InitializeComponent();
            conn = connection;
            MainWindow = main_window;
        }

        public void skl1_zaw_TextChanged(object sender, EventArgs e)  // podczas zmiany wartości zawartości składnika pasek globalnej wartości podnosi się o podaną wartość. Max 100kg 
        {
            CheckLimit();
        }

        public void skl2_zaw_TextChanged(object sender, EventArgs e) // podczas zmiany wartości zawartości składnika pasek globalnej wartości podnosi się o podaną wartość. Max 100kg 
        {
            CheckLimit();
        }

        public void add_recipe_Click(object sender, EventArgs e)
        {
            // Odczyt wartości zadanych z textboxów do zmiennych lokalnych
            string skladnik1_name = skl1_name.Text;
            string skladnik2_name = skl2_name.Text;
            string miesz_name = mieszanka_name.Text;
            int skladnik1_content = int.Parse(skl1_zaw.Text);
            int skladnik2_content = int.Parse(skl2_zaw.Text);
            int level = skladnik1_content + skladnik2_content;

            if (miesz_name.Length == 0) MessageBox.Show("Brak nazwy receptury.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (miesz_name.Length != 0)
            {
                if (skladnik1_name.Length == 0 || skladnik2_name.Length == 0) MessageBox.Show("Brak nazwy dla któregoś ze składników.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (skladnik1_name.Length != 0 && skladnik2_name.Length != 0)
                {
                    if (level < 100) MessageBox.Show("Brak 100kg dla zawartości mieszanki. Podaj zawartość składników.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (level > 100) MessageBox.Show("Suma zawartości składników wynosi ponad 100kg! Zmniejsz zawartość któregoś ze składników.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (level == 100)
                    {
                        SqlCommand add_recipe = new SqlCommand($"INSERT INTO Recipes (RecipeName, Skl1_name, Skl2_name, Skl1_procent, Skl2_procent) VALUES ('{miesz_name}', '{skladnik1_name}', '{skladnik2_name}', {skladnik1_content}, {skladnik2_content});", conn);
                        if (add_recipe.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Pomyślnie dodano recepture.", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mieszanka_name.Text = " ";
                            skl1_name.Text = " ";
                            skl2_name.Text = " ";
                            skl1_zaw.Text = "0";
                            skl2_zaw.Text = "0";
                        }
                        else MessageBox.Show("Błąd przy dodaniu receptury!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CheckLimit()
        {
            if (skl1_zaw.Text.Length == 0 || skl2_zaw.Text.Length == 0) return;
            else
            {
                int skladnik1_content = int.Parse(skl1_zaw.Text);
                int skladnik2_content = int.Parse(skl2_zaw.Text);
                int level = skladnik1_content + skladnik2_content;
                if (level <= 100)
                {
                    alarm_text.Visible = false;
                    content_level.Value = level;
                }
                else if (level > 100)
                {
                    alarm_text.Visible = true;
                    content_level.Value = 100;
                }
            }
        }

        private void Add_recipe_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlCommand SHOW_record_count = new SqlCommand("SELECT COUNT(id) FROM Recipes", conn);
          
            SqlDataReader record_count = SHOW_record_count.ExecuteReader();
            using (record_count)
            {
                while (record_count.Read()) MainWindow.rekord_count_textbox.Text = record_count.GetInt32(0).ToString();
            }
        }
    }
}
