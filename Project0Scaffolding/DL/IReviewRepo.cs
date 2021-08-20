using System.Collections.Generic;

using Models;

namespace DL
{
    public interface IReviewRepo
    {
        User AddUser(User user);

        Restaurant AddRestaurant(Restaurant restaurant);

        Review AddReview(Review review);

        List<User> AllUsers();

        List<Restaurant> AllRestaurants();

        List<Review> AllReviews();

    }
}


