using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string TrackNumber { get; set; }
        public double Length { get; set; }
        public double Popularity { get; set; }
    }
}
