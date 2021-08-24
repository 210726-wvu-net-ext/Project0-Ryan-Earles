using Models;
using DL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class ReviewRepo : IReviewRepo
    {
        private RearlesDBContext _context;
        public ReviewRepo(RearlesDBContext context)
        {
            _context = context;
        }

        public List<Models.Restaurant> AllRestaurants()
        {
            return _context.Restaurants.Select(
                Restaurant => new Models.Restaurant(Restaurant.Name, Restaurant.Id, Restaurant.Zipcode, Restaurant.Rating) //id name, zipcode, rating, 
            ).ToList();
        }
        public List<Models.Review> AllReviews()
        {
            return _context.Reviews.Select(
                Review => new Models.Review(Review.Id, Review.Title, Review.Body, Review.Rating) //id, title, body, rating
            ).ToList();
        }
        public List<Models.User> AllUsers()
        {
            return _context.Users.Select(
                User => new Models.User(User.Id, User.Name, User.Username, User.Password, User.IsAdmin) //id, name, username, password, isadmin
            ).ToList();
        }
        public List<Models.ReviewJoin> AllReviewJoin()
        {
            return _context.ReviewJoins.Select(
                ReviewJoin => new Models.ReviewJoin(ReviewJoin.RestaurantId, ReviewJoin.ReviewId, ReviewJoin.UserId) //id, name, username, password, isadmin
            ).ToList();
        }
        public Models.Restaurant AddRestaurant(Models.Restaurant restaurant) 
        {
            _context.Restaurants.Add(
                new Entities.Restaurant{
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Zipcode = restaurant.Zipcode,
                    Rating = restaurant.Rating,
                }
            );
            _context.SaveChanges();

            return restaurant;
        }
        public Models.Review AddReview(Models.Review review) 
        {
            _context.Reviews.Add(
                new Entities.Review{
                    Id = review.Id,
                    Title = review.Title,
                    Body = review.Body, 
                    Rating = review.Rating,
                }
            );
            _context.SaveChanges();

            return review;
        }
        public Models.User AddUser(Models.User user) //id, name, username, password, isadmin
        {
            _context.Users.Add(
                new Entities.User{
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Password = user.Password,
                    IsAdmin = user.isAdmin
                }
            );
            _context.SaveChanges();

            return user;
        }
        public Models.ReviewJoin AddReviewJoin(Models.ReviewJoin reviewjoin) //id, name, username, password, isadmin
        {
            _context.ReviewJoins.Add(
                new Entities.ReviewJoin{
                    Id = reviewjoin.Id,
                    RestaurantId = reviewjoin.RestaurantId,
                    ReviewId = reviewjoin.ReviewId,
                    UserId = reviewjoin.UserId
                }
            );
            _context.SaveChanges();

            return reviewjoin;
        }
        
    }
}