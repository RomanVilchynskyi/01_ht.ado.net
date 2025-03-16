using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_3.Entities
{
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<Album> Albums { get; set; }

    }
}
