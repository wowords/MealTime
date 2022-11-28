using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
