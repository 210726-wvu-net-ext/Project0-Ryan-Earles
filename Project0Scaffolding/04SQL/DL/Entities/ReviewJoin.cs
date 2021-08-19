namespace DL.Entities
{
    public partial class ReviewJoin //this is for joining the tables together supposedly
    {
        public ReviewJoin()
        {
            Restuarant = new HashSet<Restaurant>();
            Review = new HashSet<Review>();
            User = new HashSet<User>();
        }
        public virtual ICollection<Restaurant> Restaurant { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<User> User { get; set; }  
    }
}


//  public Cat()
//         {
//             Meals = new HashSet<Meal>();
//         }

//         public int Id { get; set; }
//         public string Name { get; set; }

//         public virtual ICollection<Meal> Meals { get; set; }