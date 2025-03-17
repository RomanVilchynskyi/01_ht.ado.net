using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_4.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}
