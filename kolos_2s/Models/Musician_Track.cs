using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }

        public virtual Musician IdMusicians { get; set; }
        public virtual Track IdTracks { get; set; }
    }
}
