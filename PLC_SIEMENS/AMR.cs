using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;

namespace PLC_SIEMENS
{
    public partial class AMR : Form
    {
        public AMR()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;


        private void AMR_Load(object sender, EventArgs e)
        {
            //CefSettings settings = new CefSettings();

            //Cef.Initialize(settings);
            string url = "http://192.168.0.254/index.php?auth&login=operator&pass=@!operator!@";
            chrome = chromiumWebBrowser1;
            chrome.Dock = DockStyle.Fill;
            chrome.Load(url);           
        }

        
    }

}
