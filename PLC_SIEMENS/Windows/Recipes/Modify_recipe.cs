using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Recipes
{
    public partial class Modify_recipe : Form
    {
        private readonly SqlConnection conn;
        private readonly Main MainWindow;
        public Modify_recipe(SqlConnection connection, Main main_window)
        {
            InitializeComponent();
            conn = connection;
            MainWindow = main_window;
            int skladnik1_content = int.Parse(skl1_zaw.Text);
            int skladnik2_content = int.Parse(skl2_zaw.Text);
            modify_content_level.Value = skladnik1_content + skladnik2_content;
        }
        public void skl1_zaw_TextChanged(object sender, EventArgs e)  // podczas zmiany wartości zawartości składnika pasek globalnej wartości podnosi się o podaną wartość. Max 100kg 
        {
            CheckLimit();
        }

        public void skl2_zaw_TextChanged(object sender, EventArgs e) // podczas zmiany wartości zawartości składnika pasek globalnej wartości podnosi się o podaną wartość. Max 100kg 
        {
            CheckLimit();
        }

        public void modify_recipe_button_Click(object sender, EventArgs e)
        {
            // Odczyt wartości zadanych z textboxów do zmiennych lokalnych
            int id = int.Parse(id_box.Text);
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
                        SqlCommand modify_recipe = new SqlCommand($"UPDATE Recipes SET RecipeName='{miesz_name}', Skl1_name='{skladnik1_name}', Skl2_name='{skladnik2_name}', Skl1_procent={skladnik1_content}, Skl2_procent={skladnik2_content} WHERE id =" + id, conn);
                        if (modify_recipe.ExecuteNonQuery() == 1) MessageBox.Show("Pomyślnie zmodyfikowano recepture.", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Błąd przy modyfikowaniu receptury!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Receptury_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlCommand SHOW_read_recipe = new SqlCommand($"SELECT * FROM Recipes WHERE id={id_box.Text}", conn);
            SqlDataReader read_recipe = SHOW_read_recipe.ExecuteReader();

            using (read_recipe)
            {
                while (read_recipe.Read())
                {
                    MainWindow.id_box.Text = read_recipe.GetValue(0).ToString();
                    MainWindow.miesz_name.Text = read_recipe.GetString(1);
                    MainWindow.skladnik1_name.Text = read_recipe.GetString(2);
                    MainWindow.skladnik2_name.Text = read_recipe.GetString(3);
                    MainWindow.skladnik1_zawartosc.Text = read_recipe.GetValue(4).ToString();
                    MainWindow.skladnik2_zawartosc.Text = read_recipe.GetValue(5).ToString();
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
                    modify_alarm_text.Visible = false;
                    modify_content_level.Value = level;
                }
                else if (level > 100)
                {
                    modify_alarm_text.Visible = true;
                    modify_content_level.Value = 100;
                }
            }
        }
    }
}
