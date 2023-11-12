using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public Nullable<System.DateTime> LastCreated { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
