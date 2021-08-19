using System.Collections.Generic;

namespace Models
{
    public class Restaurant
    {
        public Restaurant() {}
        public Restaurant(string name, int id, int zipcode, decimal rating)
        {
            this.Name = name;
            this.Id = id;
            this.Zipcode = zipcode;
            this.Rating = rating; 

        }
        //look into how this is set up
        public int Id {get; set;}
        public string Name {get;set;}
        public int Zipcode{ get; set; }
        public decimal Rating { get; set; }

        

    }

}
