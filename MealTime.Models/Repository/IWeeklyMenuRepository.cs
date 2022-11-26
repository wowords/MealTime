using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IWeeklyMenuRepository
    {
        void Create(WeeklyMenu menu, HashSet<int> mealIds);
        void Delete(int id);
        void Update(WeeklyMenu menu, HashSet<int> mealIds);
    }
}
