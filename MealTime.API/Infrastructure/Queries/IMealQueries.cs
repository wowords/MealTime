using MealTime.API.Infrastructure.DataObjects;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IMealQueries
    {
        Task<IEnumerable<MealDto>> GetAllMeals();
        Task<MealDto> GetMealByid(int Id);
        Task<IEnumerable<MealDto>> GetTopRatedMeals();
    }
}