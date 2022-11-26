using MealTime.Models;
using MealTime.Models.Repository;

namespace MealTime.API.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly MealTimeContext _context;
        public FoodRepository(MealTimeContext context)
        {
            _context = context;
        }

        public async void Create(Food food)
        {
            _context.Foods.Add(food);
        }

        public async void Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                //return NotFound();
            }
            _context.Foods.Remove(food);
        }
        public async void Update(Food food)
        {
            //Food food = await _context.Foods.FindAsync(foodId);
            if(food == null)
            {
                return;
            }
            _context.Foods.Update(food);
        }
    }
}
