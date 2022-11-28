using MealTime.API.Infrastructure.DataObjects;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IFoodQueries
    {
        Task<IEnumerable<FoodDto>> GetAllFoods();
        Task<IEnumerable<FoodDto>> GetTopRatedFoods();
        Task<FoodDto> GetFoodById(int Id);
    }
}
