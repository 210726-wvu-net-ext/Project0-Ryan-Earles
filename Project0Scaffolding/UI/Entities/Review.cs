using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
    }
}
