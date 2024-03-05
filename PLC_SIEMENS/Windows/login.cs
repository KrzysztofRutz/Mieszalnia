using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_SIEMENS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
          
            string login = login_combo.Text;
            string haslo = password_text.Text;
            if (login == "Kierownik" && haslo == "123456")
            {
                Opisy_Z window = new Opisy_Z();
                window.Show();
                this.Close();
            }
            else if (login == "Serwis" && haslo == "123")
            {
                Serwis window = new Serwis();
                window.Show();
                this.Close();
            }            
        }                            
    }
}
