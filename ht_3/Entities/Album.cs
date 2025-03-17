using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_3.Entities
{
    public class Album
    {
        public Album()
        {
            Tracks = new List<Track>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public List<Track> Tracks { get; set; }
        public double Rating { get; set; }
    }
}
