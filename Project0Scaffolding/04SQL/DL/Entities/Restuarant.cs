namespace DL.Entities
{
    public partial class Restuarant
    {
        //name zipcode rating
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }

    }
}