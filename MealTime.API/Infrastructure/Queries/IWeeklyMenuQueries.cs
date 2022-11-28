using MealTime.API.Infrastructure.DataObjects;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IWeeklyMenuQueries
    {
        Task<IEnumerable<WeeklyMenuDto>> GetAllMenus();
        Task<IEnumerable<WeeklyMenuDto>> GetTopRatedMenus();
        Task<WeeklyMenuDto> GetMenuById(int Id);
    }
}