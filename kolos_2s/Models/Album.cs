using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public partial class Album
    {
        public Album()
        {
            MusicLabels = new HashSet<MusicLabel>();
        }
        public int IdAlbum { get; set; }
        public String AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual ICollection<MusicLabel> MusicLabels { get; set; }
    }
}
