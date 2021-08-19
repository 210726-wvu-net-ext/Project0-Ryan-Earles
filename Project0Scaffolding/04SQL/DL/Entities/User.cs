using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
