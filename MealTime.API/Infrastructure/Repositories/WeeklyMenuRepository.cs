using MealTime.Models;

namespace MealTime.API.Infrastructure.Repositories
{
    public class WeeklyMenuRepository
    {
        private readonly MealTimeContext _context;
        public WeeklyMenuRepository(MealTimeContext context)
        {
            _context = context;
        }

        public async void Create(WeeklyMenu menu, HashSet<int> mealIds)
        {
            menu.Meals.Clear();
            if (mealIds is not null)
                _context.Meals.Where(m => mealIds.Contains(m.Id)).ToList().ForEach(meal => menu.Meals.Add(meal));
            _context.WeeklyMenus.Add(menu);
        }

        public async void Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                //return NotFound();
            }
            _context.Foods.Remove(food);
        }
        public async void Update(WeeklyMenu menu, HashSet<int> mealIds)
        {
            menu.Meals.Clear();
            if (mealIds is not null)
                _context.Meals.Where(m => mealIds.Contains(m.Id)).ToList().ForEach(meal => menu.Meals.Add(meal));
            _context.WeeklyMenus.Update(menu);
        }
    }
}
