using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class ReviewBL : IReviewBL
    {
        private IReviewRepo _repo;

        public PetBL(IReviewRepo repo)
        {
            _repo = repo;
        }
        
        public User AddUser(User user)
        {
            return _repo.AddUser(user);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return _repo.AddRestaurant(restaurant);
        }

        public Review AddReview(Review review)
        {
            return _repo.AddReview(review);
        }

        public List<User> AllUsers()
        {
            return _repo.AllUsers();
        }
        public List<Restaurant> AllRestaurants()
        {
            return _repo.AllRestaurants();
        }
        public List<Reviews> AllReviews()
        {
            return _repo.AllReviews();
        }
    }
}


