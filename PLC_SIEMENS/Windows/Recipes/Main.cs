using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PLC_SIEMENS.Windows.Recipes
{
    public partial class Main : Form
    {
        private readonly SqlConnection conn;
        public Main(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
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

        private void add_recipe_Click(object sender, EventArgs e)
        {
            var window = new Add_recipe(conn);            
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
    }
}
