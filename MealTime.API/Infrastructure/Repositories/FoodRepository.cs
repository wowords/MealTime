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

        public async Task Create(Food food)
        {
            try
            {
            CheckIfExists(food.Name);
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                throw new MealTimeException("A megadott étel nem található.");
            }
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Food food)
        {
            var local = await _context.Foods.FindAsync(food.Id);
            if (local == null)
            {
                throw new MealTimeException("Hiba történt a módosítás során.");
            }
            else
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private void CheckIfExists(string name)
        {
            Food user = _context.Foods.Where(x => x.Name == name).FirstOrDefault();
            if (user == null)
                return;
            else
                throw new MealTimeException("Az adott felhasználónév vagy email már használatban van. Kérem jelentkezzen be!");
        }
    }
}
