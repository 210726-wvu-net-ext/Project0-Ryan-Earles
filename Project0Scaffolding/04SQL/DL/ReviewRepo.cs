using Models;
using DL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class ReviewRepo : IReviewRepo
    {
        private rearlesdbContext _context;
        public PetRepo(rearlesdbContext context)
        {
            _context = context;
        }

        public List<Models.Restaurant> AllRestaurants()
        {
            return _context.Restaurant.Select(
                Restaurant => new Models.Restaurant(Restaurant.Id, Restaurant.Name, Restaurant.Zipcode, Restaurant.Rating) //id name, zipcode, rating, 
            ).ToList();
        }
        public List<Models.Review> AllReviews()
        {
            return _context.Review.Select(
                Review => new Models.Review(Review.Id, Review.Title, Review.Body) //id, title, body, rating
            ).ToList();
        }
        public List<Models.User> AllUsers()
        {
            return _context.User.Select(
                User => new Models.User(User.Id, User.Name, User.Username, User.Password) //id, name, username, password, isadmin
            ).ToList();
        }
        public Models.Restaurant AddRestaurant(Models.Restaurant restaurant) 
        {
            _context.Restaurant.Add(
                new Entities.Restaurant{
                    Id = restaurant.Id
                    Name = restaurant.Name
                    Zipcode = restaurant.Zipcode
                    Rating = restaurant.Rating
                }
            );
            _context.SaveChanges();

            return restaurant;
        }
        public Models.Review AddReview(Models.Review review) 
        {
            _context.Review.Add(
                new Entities.Review{
                    Id = review.Id
                    Title = review.Title
                    Body = review.Body
                    Rating = review.Rating
                }
            );
            _context.SaveChanges();

            return review;
        }
        public Models.User AddUser(Models.User user) //id, name, username, password, isadmin
        {
            _context.User.Add(
                new Entities.User{
                    Id = user.Id
                    Name = user.Name
                    Username = user.Username
                    Password = user.Password
                    isAdmin = user.isAdmin
                }
            );
            _context.SaveChanges();

            return user;
        }
        
    }
}