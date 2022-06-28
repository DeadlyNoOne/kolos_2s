using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class Track
    {
        public Track()
        {
            IdTracks = new HashSet<Musician_Track>();
            IdAlbums = new HashSet<Album>();
        }

        public int IdTrack { get; set; }
        public String TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }

        public virtual ICollection<Musician_Track> IdTracks { get; set; }
        public virtual ICollection<Album> IdAlbums { get; set; }
    }
}
