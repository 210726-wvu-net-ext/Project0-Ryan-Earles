using Models;
using DL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class PetRepo : IPetRepo
    {
        private petdbContext _context;
        public PetRepo(petdbContext context)
        {
            _context = context;
        }

        public List<Models.Cat> GetAllCats()
        {
            return _context.Cats.Select(
                cat => new Models.Cat(cat.Id, cat.Name)
            ).ToList();
        }

        public Models.Cat AddACat(Models.Cat cat)
        {
            _context.Cats.Add(
                new Entities.Cat{
                    Name = cat.Name
                }
            );
            _context.SaveChanges();

            return cat;
        }

        public Models.Meal AddAMeal(Models.Meal meal)
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

        public Models.Cat SearchCatByName(string name)
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