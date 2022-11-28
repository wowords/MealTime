using MealTime.API.Infrastructure.DataObjects;
using MealTime.API.Infrastructure.Queries;
using MealTime.Models;
using MealTime.Models.Repository;

namespace MealTime.API.Infrastructure.Helpers
{
    public class MenuHelper
    {
        private readonly IMealRepository _mealRepo;
        public MenuHelper(IMealQueries mealQueries, IMealRepository mealRepository)
        {
            _mealQueries = mealQueries;
            _mealRepo = mealRepository;
        }

        private async Task<Meal?> GetHealthyMeal()
        {
            var allMeals = await _mealRepo.GetMealsForEF();
            Meal? meal = allMeals.Where(x => x.HasHealthyFood == true && x.LastOnMenu <= System.DateTime.Now.AddDays(-14)).OrderBy(x => x.Rating).FirstOrDefault();
            if (meal != null)
                return meal;
            else
                return null;  
        }

        private async Task<List<Meal>> GetTopMeals()
        {
            var allMeals = await _mealRepo.GetMealsForEF();
            return allMeals.OrderBy(x => x.Rating).Take(15).Where(x => x.LastOnMenu <= System.DateTime.Now.AddDays(-14)).Take(20).ToList();
        }
        
        public async Task<WeeklyMenu> GenerateWeeklyMenu()
        {
            bool typeUsed = false;
            WeeklyMenu weeklyMenu = new WeeklyMenu()
            {
                Meals = new List<Meal>()
            };
            try
            {
                var healthyMeal = await GetHealthyMeal();
                if (healthyMeal is not null)
                    weeklyMenu.Meals.Add(healthyMeal);
                var meals = await GetTopMeals();
                foreach (var meal in meals.Shuffle())
                {
                    typeUsed = false;
                    if (weeklyMenu.Meals.Count >= 7)
                        break;
                    foreach (var item in meal.Foods)
                    {
                        var foods = weeklyMenu.Meals.Select(x => x.Foods);
                        if (foods.Select(x => x.Select(y => y.Type).ToList().Contains(item.Type)).FirstOrDefault())
                            typeUsed = true;
                    }
                    if (!typeUsed)
                        weeklyMenu.Meals.Add(meal);
                }
                weeklyMenu.CurrentWeek = GetNextWeekday(DayOfWeek.Monday);
                await _mealRepo.SetLastTimeOnMenu(weeklyMenu.Meals.Select(x => x.Id).ToList());
                return weeklyMenu;
            }
            catch (Exception e)
            {
                throw new MealTimeException("Hiba történt a következő heti menü létrehozása közben:" + e.Message);
            }
            
            
        }
        static DateTime GetNextWeekday(DayOfWeek day)
        {
            DateTime result = DateTime.Now.AddDays(1);
            while (result.DayOfWeek != day)
                result = result.AddDays(1);
            return result;
        }
    }
    public static class EnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
