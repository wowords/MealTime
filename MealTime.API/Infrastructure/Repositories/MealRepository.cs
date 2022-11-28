using MealTime.API.Infrastructure.DataObjects;
using MealTime.API.Infrastructure.Queries;
using MealTime.Models;
using MealTime.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace MealTime.API.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly MealTimeContext _context;
        private readonly IFoodQueries _foodQueries;
        public MealRepository(MealTimeContext context, IFoodQueries foodQueries)
        {
            _context = context;
            _foodQueries = foodQueries;
        }

        public async Task Create(Meal meal, HashSet<int> foodIds)
        {
            try
            {
            if (foodIds is not null)
                {
                    (meal.HasHealthyFood, meal.Rating) = await GetHealthinessAndRating(foodIds.ToList());
                    _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => 
                    {
                        meal.Foods.Add(food);
                        if (food.IsHealthy == true && meal.HasHealthyFood == false)
                            meal.HasHealthyFood = true;
                     });
                }
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
        public async Task Update(int mealId, HashSet<int>? foodIds)
        {

            Meal meal = await _context.Meals.FindAsync(mealId);
            if(meal == null)
                throw new MealTimeException("Hiba történt a módosítás során.");
            if(foodIds is not null)
            {
                meal.Foods.Clear();
                _context.Foods.Where(f => foodIds.Contains(f.Id)).ToList().ForEach(food => meal.Foods.Add(food));
                (meal.HasHealthyFood, meal.Rating) = await GetHealthinessAndRating(foodIds.ToList());
            }
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();
        }

        public async Task SetLastTimeOnMenu(List<int> mealIds)
        {
            foreach (var item in mealIds)
            {
                var meal = await _context.Meals.FindAsync(item);
                meal.LastOnMenu = System.DateTime.Now;
                _context.Meals.Update(meal);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<(bool, double)> GetHealthinessAndRating(List<int> foodIds)
        {
            bool HasHealthyFood = false;
            double rating = 0;
            foreach (var item in foodIds)
            {
                FoodDto food = await _foodQueries.GetFoodById(item);
                if (food.IsHealthy)
                    HasHealthyFood = true;
                rating =+ food.Rating;

            }
            return(HasHealthyFood, rating);
        }
        public async Task<IEnumerable<Meal>> GetMealsForEF()
        {
            return _context.Meals.Include(f => f.Foods).ToList();
        }
    }
}
