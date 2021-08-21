using System.Collections.Generic;

namespace Models
{
    public class Restaurant
    {
        public Restaurant() {}
        public Restaurant(string name, int zipcode, decimal rating)
        {
            this.Name = name;
            this.Zipcode = zipcode;
            this.Rating = rating; 

        }
        public Restaurant(string name, int id, int zipcode, decimal rating) : this(name, zipcode, rating)
        {
            this.Id = id;
        }
        //look into how this is set up
        public int Id {get; set;}
        public string Name {get;set;}
        public int Zipcode{ get; set; }
        public decimal Rating { get; set; }
        public List<ReviewJoin> ReviewJoins {get;set;}

        

    }

}


