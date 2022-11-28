using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IMealRepository
    {
        Task Create(Meal meal, HashSet<int> foodIds);
        Task Delete(int id);
        Task Update(int mealId, HashSet<int> foodIds);
        Task<IEnumerable<Meal>> GetMealsForEF();
        Task SetLastTimeOnMenu(List<int> mealIds);
    }
}
