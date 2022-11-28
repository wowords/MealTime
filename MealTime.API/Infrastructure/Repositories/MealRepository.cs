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

        public async Task Create(Meal meal, HashSet<int> foodIds)
        {
            try
            {
            if (foodIds is not null)
                _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => 
                {
                    meal.Foods.Add(food);
                    if (food.IsHealthy == true && meal.HasHealthyFood == false)
                        meal.HasHealthyFood = true;
                 });
            else
                throw new MealTimeException("Hiba történt a létrehozás során.");
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                throw new MealTimeException("Hiba történt a törlés során.");
            }
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Meal meal, HashSet<int> foodIds)
        {
            meal.Foods.Clear();
            if (foodIds is not null)
                _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => meal.Foods.Add(food));
            var local = await _context.Meals.FindAsync(meal.Id);
            if (local == null)
                throw new MealTimeException("Hiba történt a módosítás során.");
            else
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(meal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
