using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Controller
{
    public class ArtistController
    {
        public static void AgregarArtist(Artist artist)
        {
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PA_Insertar_Artist";

            cmd.Parameters.AddWithValue("@pName", artist.Name);
            cmd.Parameters.AddWithValue("@pIdTrack", artist.IdTrack);

            cmd.ExecuteNonQuery();

            Conexion.Cerrar();
        }

        public static List<Artist> ListaArtist()
        {
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandText = @"select distinct(ar.name) Nombre from tbl_Artist ar";

            List<Artist> listaArtist = new List<Artist>();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                Artist ar = new Artist();
                ar.Name = reader["Nombre"].ToString();
                listaArtist.Add(ar);
            }
            Conexion.Cerrar();
            return listaArtist;
        }
    }
}
