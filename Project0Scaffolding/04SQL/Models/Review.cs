namespace Models
{
    public class Review
    {
        public Review() {}
        public Review(int id, string title, string body, decimal rating)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.Rating = rating; 

        }
        //look into how this is set up
        public int Id {get; set;}
        public string Title {get;set;}
        public string Body { get; set; }
        public decimal Rating { get; set; }
    }
}