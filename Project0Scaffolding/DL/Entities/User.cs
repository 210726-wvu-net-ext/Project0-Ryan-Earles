using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            ReviewJoins = new HashSet<ReviewJoin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<ReviewJoin> ReviewJoins { get; set; }
    }
}


