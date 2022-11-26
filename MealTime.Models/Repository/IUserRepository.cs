using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GettUsers();
        Task<IEnumerable<User>> GetAdminUsers();
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
