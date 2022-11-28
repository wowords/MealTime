using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IWeeklyMenuRepository
    {
        Task Create(WeeklyMenu menu);
        Task Delete(int id);
        Task Update(WeeklyMenu menu, HashSet<int> mealIds);
        Task<IEnumerable<WeeklyMenu>> GetAllMenus();

        Task<WeeklyMenu> GetThisWeekMenu();
        Task<WeeklyMenu> GetNextWeekMenu();
    }
}
