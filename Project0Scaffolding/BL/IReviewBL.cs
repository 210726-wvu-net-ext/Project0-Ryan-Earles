using Models;
using System.Collections.Generic;

namespace BL
{
    public interface IReviewBL
    {
        
        User AddUser(User user); //method takes a user and adds it to the db
        ReviewJoin AddReviewJoin(ReviewJoin reviewjoin);
        Restaurant AddRestaurant(Restaurant restaurant);
        Review AddReview(Review review);
        List<User> AllUsers();
        List<Restaurant> AllRestaurants();
        List<Review> AllReviews();
        List<ReviewJoin> AllReviewJoin();
    }
}