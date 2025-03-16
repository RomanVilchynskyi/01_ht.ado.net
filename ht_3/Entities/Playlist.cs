using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_3.Entities
{
    public class Playlist
    {
        public Playlist()
        {
            Tracks = new List<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Track> Tracks { get; set; }

    }
}
