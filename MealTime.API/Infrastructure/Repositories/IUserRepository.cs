using MealTime.Models;

namespace MealTime.API.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GettUsers();
        IEnumerable<User> GetAdminUsers();
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
