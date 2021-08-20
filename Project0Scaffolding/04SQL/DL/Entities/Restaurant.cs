using System;
using System.Collections.Generic;


namespace DL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Restaurants = new HashSet<Restaurant>();
        }
        //name zipcode rating
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

    }
}