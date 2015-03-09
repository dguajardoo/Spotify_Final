using Spotify.Controller;
using Spotify.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Spotify
{
    public partial class Default : System.Web.UI.Page
    {
        Track t1        = new Track();
        Artist a1       = new Artist();
        Album a2        = new Album();
        Availability a3 = new Availability();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombo();
            }
        }

        private void CargarXML(string query)
        {
            string xml = "https://ws.spotify.com/search/1/track.xml?q=" + query;
            XmlDocument documento = new XmlDocument();
            documento.Load(xml);
            XmlNodeList tracks = documento.GetElementsByTagName("tracks");
            foreach (XmlElement nodoTracks in tracks)
            {
                XmlNodeList track = nodoTracks.GetElementsByTagName("track");
                foreach (XmlElement nodoTrack in track)
                {
                    XmlNodeList nameTrack   = nodoTrack.GetElementsByTagName("name");
                    XmlNodeList id          = nodoTrack.GetElementsByTagName("id");
                    XmlNodeList trackNumber = nodoTrack.GetElementsByTagName("track-number");
                    XmlNodeList length      = nodoTrack.GetElementsByTagName("length");
                    XmlNodeList popularity  = nodoTrack.GetElementsByTagName("popularity");

                    t1.Name         = nameTrack[0].InnerText;
                    t1.Id           = id[0].InnerText;
                    t1.TrackNumber  = trackNumber[0].InnerText;
                    t1.Length       = Convert.ToDouble(length[0].InnerText);
                    t1.Popularity   = Convert.ToDouble(popularity[0].InnerText);

                    TrackController.AgregarTrack(t1);

                    XmlNodeList artist = ((XmlElement)nodoTrack).GetElementsByTagName("artist");
                    foreach (XmlElement nodoArtist in artist)
                    {
                        XmlNodeList nameArtist = nodoArtist.GetElementsByTagName("name");

                        a1.Name     = nameArtist[0].InnerText;
                        a1.IdTrack  = TrackController.ObtenerIdTrack();

                        ArtistController.AgregarArtist(a1);
                    }
                    XmlNodeList album = ((XmlElement)nodoTrack).GetElementsByTagName("album");
                    foreach (XmlElement nodoAlbum in album)
                    {
                        XmlNodeList nameAlbum   = nodoAlbum.GetElementsByTagName("name");
                        XmlNodeList released    = nodoAlbum.GetElementsByTagName("released");

                        a2.Name = nameAlbum[0].InnerText;
                        a2.Released = released[0].InnerText;
                        a2.IdTrack = TrackController.ObtenerIdTrack();

                        AlbumController.AgregarAlbum(a2);

                        XmlNodeList availability = ((XmlElement)nodoAlbum).GetElementsByTagName("availability");
                        foreach (XmlElement nodoAvailability in availability)
                        {
                            XmlNodeList territories = nodoAvailability.GetElementsByTagName("territories");

                            a3.Territories = territories[0].InnerText;
                            a3.IdAlbum = AlbumController.ObtenerIdAlbum();

                            AvailabilityController.AgregarAvailability(a3);

                        }
                    }

                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarXML(txtConsulta.Text);
            CargarCombo();
        }

        private void CargarCombo()
        {
            ddlArtista.DataSource = ArtistController.ListaArtist();
            ddlArtista.DataTextField = "Name";
            ddlArtista.DataValueField = "Name";
            ddlArtista.DataBind();
            ddlArtista.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        private void CargarGrilla()
        {
            string artist = ddlArtista.SelectedValue;

            gvInformacion.DataSource = TrackController.BuscarArtista(artist);
            gvInformacion.DataBind();
        }

        protected void ddlArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            string artist = ddlArtista.SelectedValue;

            gvInformacion.DataSource = TrackController.BuscarArtista(artist);
            gvInformacion.DataBind();
        }
    }
}