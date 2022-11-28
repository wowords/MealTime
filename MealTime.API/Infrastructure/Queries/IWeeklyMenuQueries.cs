using MealTime.API.Infrastructure.DataObjects;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IWeeklyMenuQueries
    {
        Task<WeeklyMenuDto> GetMenuById(int Id);
    }
}