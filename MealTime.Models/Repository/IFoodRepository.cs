using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IFoodRepository
    {
        void Create(Food food);
        void Delete(int id);
        void Update(Food food);
    }
}
