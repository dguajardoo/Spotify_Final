﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Model
{
    public class Album
    {
        public int IdArtist { get; set; }
        public string Name { get; set; }
        public string Released { get; set; }
        public int IdTrack { get; set; }
    }
}
