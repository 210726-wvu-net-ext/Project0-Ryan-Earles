using Models;
using DL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class PetRepo : IPetRepo
    {
        private rearlesdbContext _context;
        public PetRepo(rearlesdbContext context)
        {
            _context = context;
        }

        public List<Models.Cat> GetAllCats() //getting everything available this will be used in getting all the Rests, all the reviews, all the users
        {
            return _context.Cats.Select(
                cat => new Models.Cat(cat.Id, cat.Name)
            ).ToList();
        }
        

        public Models.Cat AddACat(Models.Cat cat) //example of adding a user, a restaurant, or a review
        {
            _context.Cats.Add(
                new Entities.Cat{
                    Name = cat.Name
                }
            );
            _context.SaveChanges();

            return cat;
        }

        public Models.Meal AddAMeal(Models.Meal meal) ///example of potentially a join?
        {
            _context.Meals.Add(
                new Entities.Meal {
                    Time = meal.Time,
                    FoodType = meal.FoodType,
                    CatId = meal.CatId
                }
            );
            _context.SaveChanges();

            return meal;
        }

        public Models.Cat SearchCatByName(string name) //an example of searching for a value for the search stuff
        {
            Entities.Cat foundCat =  _context.Cats
                .FirstOrDefault(cat => cat.Name == name);
            if(foundCat != null)
            {
                return new Models.Cat(foundCat.Id, foundCat.Name);
            }
            return new Models.Cat();
        }        
    }
}