using System;
using System.Collections.Generic;


namespace DL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            ReviewJoins = new HashSet<ReviewJoin>();
        }
        //name zipcode rating
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<ReviewJoin> ReviewJoins { get; set; }

    }
}


