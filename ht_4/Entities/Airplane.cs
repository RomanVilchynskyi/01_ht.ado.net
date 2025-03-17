using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_4.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int MaxPassengers { get; set; }
        public string Country { get; set; }
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}
