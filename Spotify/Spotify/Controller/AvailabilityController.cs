using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Controller
{
    public class AvailabilityController
    {
        public static void AgregarAvailability(Availability availability)
        {
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PA_Insertar_Availability";

            cmd.Parameters.AddWithValue("@pTerritories", availability.Territories);
            cmd.Parameters.AddWithValue("@pIdAlbum", availability.IdAlbum);

            cmd.ExecuteNonQuery();

            Conexion.Cerrar();
        }

        
    }
}
