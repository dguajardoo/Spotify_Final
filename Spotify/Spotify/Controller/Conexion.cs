using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Controller
{
    class Conexion
    {
        private static SqlConnection conn;

        public static SqlCommand Conectar()
        {

            conn = new SqlConnection("Data Source=DAVID-PC\\SQLEXPRESS;Initial Catalog=Spotify;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            return cmd;
        }

        public static void Cerrar()
        {
            conn.Close();
        }

    }
}
