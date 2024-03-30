using System;
using System.Threading.Tasks;
using CefSharp.WinForms.Internals;
using S7.Net;

namespace PLC_SIEMENS.Definitions
{
    public static class PLC
    {
        private readonly static Error_PLC error_window = new Error_PLC();
        public readonly static Plc plc = new Plc(CpuType.S71200, "192.168.0.202", 0, 1);

        public static async Task connect()
        {
            if (plc.IsConnected == false)
            {
                try
                {
                    await plc.OpenAsync();
                    if (error_window.IsActiveControl()) error_window.Close();
                }
                catch
                {                   
                    if (!error_window.Visible & !error_window.IsActiveControl()) error_window.ShowDialog();
                }
            }
            else error_window.Close();
        }

        public static async Task<bool> readBool(string variable)
        {          
            bool ret_value = false;
            if (plc.IsConnected)
            {
                try { ret_value = Convert.ToBoolean(await plc.ReadAsync(variable)); }
                catch { await connect(); }
            }            
            else await connect();

            return ret_value;
        }

        public static async Task writeBool(string variable, bool value)
        {
            if (plc.IsConnected)
            {
                try { await plc.WriteAsync(variable, value); }
                catch { await connect(); }
            }           
            else await connect();
        }

        public static async Task<object> analog_read(int nr_DB, int zmienna, VarType type, int count = 1)
        {
            var variable = new object();
            int zero = 0;
            if (plc.IsConnected)
            {
                try { variable = await plc.ReadAsync(DataType.DataBlock, nr_DB, zmienna, type, count); }
                catch
                {
                    variable = zero;
                    await connect();
                }
            }
            else
            {
                variable = zero;
                await connect();
            }
            return variable;
        }

        public static async Task analog_write(string variable, object value)
        {
            if (plc.IsConnected)
            {
                try { await plc.WriteAsync(variable, value); }
                catch { await connect(); }
            }
            else await connect();
        }
    }
}
