using System;
using System.Collections.Generic;
namespace Models
{
    public class Review
    {
        public Review() {}
        public Review(string title, string body, decimal rating, int irestuarant)
        {
            this.Title = title;
            this.Body = body;
            this.Rating = rating; 
            this.IRestuarant = irestuarant;

        }
        public Review(int id, string title, string body, decimal rating, int irestuarant) : this(title, body, rating, irestuarant) 
        {

            this.Id = id;
        }

        //look into how this is set up
        public int IRestuarant { get; set; }
        public int Id {get; set;}
        public string Title {get;set;}
        public string Body { get; set; }
        public decimal Rating { get; set; }
        public List<ReviewJoin> ReviewJoins {get;set;}
    }
}


