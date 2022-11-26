using MealTime.Models;
using MealTime.Models.Repository;

namespace MealTime.API.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly MealTimeContext _context;
        public MealRepository(MealTimeContext context)
        {
            _context = context;
        }

        public async void Create(Meal meal, HashSet<int> foodIds)
        {
            meal.Foods.Clear();
            if (foodIds is not null)
                _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => meal.Foods.Add(food));
            else
                return;
            _context.Meals.Add(meal);
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
        public async void Update(Meal meal, HashSet<int> foodIds)
        {
            meal.Foods.Clear();
            if (foodIds is not null)
                _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => meal.Foods.Add(food));
            else
                return;
            _context.Meals.Update(meal);
        }
    }
}
