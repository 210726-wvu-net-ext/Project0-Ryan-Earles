using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Rating { get; set; }
        public int Irestuarant { get; set; }
    }
}
