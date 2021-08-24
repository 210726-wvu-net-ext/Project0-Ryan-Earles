using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class ReviewBL : IReviewBL
    {
        private IReviewRepo _repo;

        public ReviewBL(IReviewRepo repo)
        {
            _repo = repo;
        }
        
        public User AddUser(User user)
        {
            return _repo.AddUser(user);
        }
        public ReviewJoin AddReviewJoin(ReviewJoin reviewjoin)
        {
            return _repo.AddReviewJoin(reviewjoin);
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
        public List<Review> AllReviews()
        {
            return _repo.AllReviews();
        }
        public List<ReviewJoin> AllReviewJoin()
        {
            return _repo.AllReviewJoin();
        }
    }
}


