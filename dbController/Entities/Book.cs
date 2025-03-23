using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbController.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public float CostPrice { get; set; }
        public float SalePrice { get; set; }
        public bool IsContinuation { get; set; }
    }

}
