using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeportenisUTH.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> LastCreated { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}