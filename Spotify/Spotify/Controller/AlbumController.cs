using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Controller
{
    public class AlbumController
    {
        public static void AgregarAlbum(Album album)
        {
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PA_Insertar_Album";

            cmd.Parameters.AddWithValue("@pName", album.Name);
            cmd.Parameters.AddWithValue("@pReleased", album.Released);
            cmd.Parameters.AddWithValue("@pIdTrack", album.IdTrack);

            cmd.ExecuteNonQuery();

            Conexion.Cerrar();
        }

        public static int ObtenerIdAlbum()
        {
            int id = 0;
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandText = @"SELECT MAX(idAlbum) FROM tbl_Album";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) id = Convert.ToInt32(reader[0]);

            Conexion.Cerrar();

            return id;
        }
    }
}
