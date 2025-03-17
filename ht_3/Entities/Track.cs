using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_3.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public int PlayCount { get; set; } 
        public string Lyrics { get; set; }
    }

}
