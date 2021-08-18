using Models;
using System.Collections.Generic;

namespace BL
{
    public interface IPetBL
    {
        List<Cat> ViewAllCats();
        Cat AddACat(Cat cat);
        Meal AddAMeal(Meal meal);
        Cat SearchCatByName(string name);
    }
}