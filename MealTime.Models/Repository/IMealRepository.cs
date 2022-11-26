using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTime.Models.Repository
{
    public interface IMealRepository
    {
        void Create(Meal meal, HashSet<int> foodIds);
        void Delete(int id);
        void Update(Meal meal, HashSet<int> foodIds);
    }
}
