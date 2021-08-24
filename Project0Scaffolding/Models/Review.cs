using System;
using System.Collections.Generic;
namespace Models
{
    public class Review
    {
        public Review() {}
        public Review(string title, string body, decimal rating)
        {
            this.Title = title;
            this.Body = body;
            this.Rating = rating; 

        }
        public Review(int id, string title, string body, decimal rating) : this(title, body, rating) 
        {

            this.Id = id;
        }

        //look into how this is set up
        public int Id {get; set;}
        public string Title {get;set;}
        public string Body { get; set; }
        public decimal Rating { get; set; }
    }
}


