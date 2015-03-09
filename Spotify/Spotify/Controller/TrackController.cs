using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Controller
{
    public class TrackController
    {
        public static void AgregarTrack(Track track)
        {
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PA_Insertar_Track";

            cmd.Parameters.AddWithValue("@pName", track.Name);
            cmd.Parameters.AddWithValue("@pId", track.Id);
            cmd.Parameters.AddWithValue("@pTrackNumber", track.TrackNumber);
            cmd.Parameters.AddWithValue("@pLength", track.Length);
            cmd.Parameters.AddWithValue("@pPopularity", track.Popularity);

            cmd.ExecuteNonQuery();

            Conexion.Cerrar();
        }

        public static int ObtenerIdTrack()
        {
            int id = 0;
            SqlCommand cmd = Conexion.Conectar();
            cmd.CommandText = @"SELECT MAX(idTrack) FROM tbl_Track";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) id = Convert.ToInt32(reader[0]);

            Conexion.Cerrar();

            return id;
        }

        public static DataTable BuscarArtista(string artist)
        {
            DataTable DtResultado = new DataTable();
            try
            {
                SqlCommand sqlcmd = Conexion.Conectar();
                sqlcmd.CommandText = @"SELECT 
                                            DISTINCT(al.name) Album
                                            , al.released Año
                                            , AVG(tr.popularity) Popularidad
                                            , tr.name Cancion
                                            , MAX(tr.length/1000000) Segundos 
                                    FROM 
                                            tbl_Track tr 
                                    INNER JOIN 
                                            tbl_Artist ar 
                                    ON 
                                            tr.idTrack = ar.idTrack 
                                    INNER JOIN 
                                            tbl_Album al 
                                    ON 
                                            tr.idTrack = al.idTrack 
                                    WHERE 
                                            ar.name = @artist
                                    GROUP BY 
                                            al.name
                                            , al.released
                                            , tr.name 
                                            ,tr.length
                                    ORDER BY 
                                            al.released 
                                    DESC
";

                sqlcmd.Parameters.AddWithValue("@artist", artist);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(DtResultado);
            }
            catch (Exception e)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
