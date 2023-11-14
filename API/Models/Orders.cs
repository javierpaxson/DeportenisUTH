using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Hour { get; set; }
        public Nullable<System.DateTime> LastCreated { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
