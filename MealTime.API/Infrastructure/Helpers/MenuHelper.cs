using MealTime.API.Infrastructure.DataObjects;
using MealTime.API.Infrastructure.Queries;
using MealTime.Models;

namespace MealTime.API.Infrastructure.Helpers
{
    public class MenuHelper
    {
        private readonly IMealQueries _mealQueries;
        public MenuHelper(IMealQueries mealQueries)
        {
            _mealQueries = mealQueries;
        }

        //get all healthy meal && was not on last 2 weeks menu, get top 1 from these
        private async Task<MealDto?> GetHealthyMeal()
        {
            var allMeals = await _mealQueries.GetAllMeals();
            MealDto? meal = allMeals.Where(x => x.HasHealthyFood == true && x.LastOnMenu >= System.DateTime.Now.AddDays(-14)).OrderBy(x => x.Rating).FirstOrDefault();
            if (meal == null)
                return meal;
            else
                return null;  
        }

        //get top x ratings meal which was not included last 2 week
        private async Task<List<MealDto>> GetTopMeals()
        {
            var allmeals = await _mealQueries.GetAllMeals();
            return allmeals.OrderBy(x => x.Rating).Take(15).Where(x => x.LastOnMenu >= System.DateTime.Now.AddDays(-14)).Take(15).ToList();
        }
        //Meal must include 1 started, 1 maindish, 1 dessert
        //TODO WeeklyMenu cannot have 2 of same Foodcategory
        //private async Task<List<MealDto>> GetWeeklyMeals()
        //{
        //    var dailyMeals = new List<MealDto>();
        //    foreach (var meal in await GetTopMeals())
        //    {
        //        switch (meal.)
        //        {
        //            default:
        //                break;
        //        }
        //    }
        //}
        //generate WeeklyMenu for next week, set foods LastWeekonMenu attribute.
        private async Task<WeeklyMenuDto> GenerateWeeklyMenu()
        {
            WeeklyMenuDto weeklyMenu = new WeeklyMenuDto();
            var healthyMeal = await GetHealthyMeal();
            if(healthyMeal is not null)
                weeklyMenu.Meals.Add(healthyMeal);
            
        }
    }
}
