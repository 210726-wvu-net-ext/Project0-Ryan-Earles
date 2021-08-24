using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class ReviewJoin
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
    }
}
