using MealTime.API.Infrastructure.DataObjects;

namespace MealTime.API.Infrastructure.Queries
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}
