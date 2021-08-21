using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Entities
{
    public partial class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }
        public decimal Rating { get; set; }
    }
}
