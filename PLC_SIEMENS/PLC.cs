using System;
using System.Threading.Tasks;
using CefSharp.WinForms.Internals;
using S7.Net;

namespace PLC_SIEMENS
{
    public static class PLC
    {
        public static Plc plc;
        private readonly static Error_PLC error_window = new Error_PLC();

        public static void connect()
        {
            var plc_ = new Plc(CpuType.S71200, "192.168.0.202", 0, 1);
            plc = plc_;
            //var window = new Error_PLC();

            if (plc_.IsConnected == false)
            {
                try
                {
                    plc.Open();
                }
                catch
                {
                    if (!error_window.IsActiveControl()) error_window.ShowDialog();
                }
            }
            else error_window.Close();         
        }

        public static async Task<bool> readBool(string variable)
        {          
            bool ret_value = false;
            if (plc.IsConnected) ret_value =  Convert.ToBoolean(await plc.ReadAsync(variable));
            else connect();

            return ret_value;
        }

        public static async Task writeBool(string variable, bool value)
        {
            if (plc.IsConnected) await plc.WriteAsync(variable, value);
            else connect();
        }

        public static async Task<double> analog_read(int nr_DB, int zmienna)
        {
            short variable = new short();
            if (plc.IsConnected) variable =  Convert.ToInt16(await plc.ReadAsync(DataType.DataBlock, nr_DB, zmienna, VarType.Int, 1));
            else connect();

            return variable;
        }

        public static async Task analog_write(string variable, short value)
        {
            if (plc.IsConnected) await plc.WriteAsync(variable, value);
            else connect();
        }
    }
}
