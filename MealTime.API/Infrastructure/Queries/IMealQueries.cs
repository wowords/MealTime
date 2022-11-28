using MealTime.API.Infrastructure.DataObjects;
using MealTime.Models;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IMealQueries
    {
        Task<IEnumerable<Meal>> GetAllMeals();
        Task<Meal> GetMealByid(int Id);
        Task<IEnumerable<Meal>> GetTopRatedMeals();
    }
}