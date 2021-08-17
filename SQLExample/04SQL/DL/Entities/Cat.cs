using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public partial class Cat
    {
        public Cat()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
