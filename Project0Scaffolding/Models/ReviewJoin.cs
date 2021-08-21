using System;
using System.Collections.Generic;
namespace Models
{
    public class ReviewJoin
    {
        public ReviewJoin() {}
        public ReviewJoin(int restuarantid, int reviewid, int userid)
        {
            this.RestaurantId = restuarantid;
            this.ReviewId = reviewid;
            this.UserId = userid;
        }

        //look into how this is set up
        public int RestaurantId {get; set;}
        public int ReviewId {get;set;}
        public int UserId { get; set; }

    }
}



