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
    public partial class login_main : Form
    {
        public login_main()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
          
            string login = login_combo.Text;
            string haslo = password_text.Text;
            if (login == "Kierownik" && haslo == "123456")
            {
                //Main.instance.Enabled = true;
                //Main.instance.user_label.Text = login;
                this.Close();
            }
            else if (login == "Serwis" && haslo == "123")
            {
                //Main.instance.Enabled = true;
                //Main.instance.user_label.Text = login;
                this.Close();
            }
            else if (login == "Operator" && haslo == "")
            {               
                //Main.instance.Enabled = true;
               // Main.instance.user_label.Text = login;
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Main.instance.Close();
        }
      
       
        
    }
}
