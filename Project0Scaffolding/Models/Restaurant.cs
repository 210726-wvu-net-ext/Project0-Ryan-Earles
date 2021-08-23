using System.Collections.Generic;

namespace Models
{
    public class Restaurant
    {
        public Restaurant() {}
        public Restaurant(string name, int zipcode, decimal rating, int count)
        {
            this.Name = name;
            this.Zipcode = zipcode;
            this.Rating = rating; 
            this.Cnt = count; 
        }
        public Restaurant(string name, int id, int zipcode, decimal rating, int count) : this(name, zipcode, rating, count)
        {
            this.Id = id;
        }
        //look into how this is set up
        public int Cnt { get; set; }
        public int Id {get; set;}
        public string Name {get;set;}
        public int Zipcode{ get; set; }
        public decimal Rating { get; set; }
        public List<ReviewJoin> ReviewJoins {get;set;}

        

    }

}


