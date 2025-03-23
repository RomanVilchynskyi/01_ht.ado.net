using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbController.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime SaleDate { get; set; }
        public float SalePrice { get; set; }
    }
}
