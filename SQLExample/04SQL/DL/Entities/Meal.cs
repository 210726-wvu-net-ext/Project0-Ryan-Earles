using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class Meal
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int? CatId { get; set; }
        public string FoodType { get; set; }

        public virtual Cat Cat { get; set; }
    }
}
