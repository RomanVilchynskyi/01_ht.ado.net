using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbController.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservedUntil { get; set; }
    }
}
