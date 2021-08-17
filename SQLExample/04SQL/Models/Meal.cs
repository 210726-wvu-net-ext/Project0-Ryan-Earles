using System;

namespace Models
{
    public class Meal
    {
        public Meal() {}
        public Meal(int catId, string foodType)
        {
            this.Time = DateTime.Now;
            this.CatId = catId;
            this.FoodType = foodType;
        }

        public DateTime Time {get;set;}
        public string FoodType {get;set;}
        public int CatId {get;set;}
    }
}