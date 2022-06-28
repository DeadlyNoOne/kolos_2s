using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class Musician
    {
        public Musician()
        {
            MusicianTracks = new HashSet<Musician_Track>();
        }

        public int IdMusician { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Nickname { get; set; }

        public virtual ICollection<Musician_Track> MusicianTracks { get; set; }
    }
}
