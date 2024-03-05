using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PLC_SIEMENS
{
    public class DB
    {
        public void connect()
        {
            //Połączenie z bazą danych sql server
            var conn = new SqlConnection("Data Source = DESKTOP-2LGV1R3; Initial Catalog= Mieszalnia; Integrated Security = true");
          
            try { conn.Open(); }
            catch 
            { 
                conn.Dispose();
                MessageBox.Show("Brak połączenia z bazą danych", "Błąd");
            }
        }
    }
}
