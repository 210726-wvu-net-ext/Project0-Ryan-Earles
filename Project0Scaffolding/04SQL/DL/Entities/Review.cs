using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
