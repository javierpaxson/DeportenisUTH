using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Products
    {
        public int Id { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<decimal> SaleOff { get; set; }
        public System.DateTime Date { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> LastCreated { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
