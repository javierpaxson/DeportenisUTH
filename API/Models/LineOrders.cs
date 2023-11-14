using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class LineOrders
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Units { get; set; }
        public Nullable<System.DateTime> LastCreated { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
