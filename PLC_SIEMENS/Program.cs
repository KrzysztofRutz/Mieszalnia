using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLC_SIEMENS.Definitions;

namespace PLC_SIEMENS
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Task.Run(async () => await DefinitionAlarm.init());
            Task.Run(async () => await PLC.connect());           
            Application.Run(new Main());
        }
    }   
}
