using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IFoodRepository
    {
        Task Create(Food food);
        Task Delete(int id);
        Task Update(Food food);
    }
}
