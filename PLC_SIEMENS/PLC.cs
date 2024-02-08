using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.DevTools.WebAudio;
using CefSharp.WinForms.Internals;
using S7.Net;

namespace PLC_SIEMENS
{
    public class PLC : Form
    {
        public static Plc plc;
        public static bool isconnected;
        public static readonly Main main = new Main();
         
        //public void connect()
        public PLC()
        {
            connect();
        }

        public void connect()
        {
            var plc_ = new Plc(CpuType.S71200, "192.168.0.202", 0, 1);
            plc = plc_;            
            //var window = new Main();
            //isconnected = plc_.IsConnected;        
            try
            {
                if (plc_.IsConnected == false)
                {
                    plc.Open();
                }
                else
                {
                    main.ERROR_PLC_label.Visible = false;
                }
            }
            catch (Exception ex)
            {
                if (main.ERROR_PLC_label.Visible == false)
                {
                    main.ERROR_PLC_label.Visible = true;
                    MessageBox.Show("Brak połączenia z PLC Siemens.", "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }

            isconnected = plc_.IsConnected;
        }

        public bool read_bool(string variable)
        {
            bool read_value = false;
            if (isconnected)
            {
                try
                {
                    read_value = (bool)plc.Read(variable);
                }
                catch
                {
                    connect();
                }                
            }
            else 
            {
                connect();                
            }            
            return read_value;
        }

        public void write_bool(string variable)
        {
            if (isconnected)
            {
                plc.Write(variable, true);
            }
            else
            {
                connect();
            }
        }
    }        
}
