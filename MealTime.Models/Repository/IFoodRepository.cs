using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IFoodRepository
    {
        void Create(Meal meal, HashSet<int> foodIds);
        void Delete(int id);
        void Update(Food food);
    }
}
