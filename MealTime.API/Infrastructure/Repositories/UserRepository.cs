using MealTime.Models;
using MealTime.Models.Repository;
using System.Globalization;

namespace MealTime.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MealTimeContext _context;
        public UserRepository(MealTimeContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {
            CheckIfExists(user.Email, user.UserName);  
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new MealTimeException("A megadott felhasználó nem található.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var local = await _context.Users.FindAsync(user.Id);
            if(local == null)
                throw new MealTimeException("Hiba történt a módosítás során.");
            else
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private void CheckIfExists(string email, string username)
        {
            User user = _context.Users.Where(x => x.Email == email || x.UserName == username).FirstOrDefault();
            if (user == null)
                return;
            else
                throw new MealTimeException("Az adott felhasználónév vagy email már használatban van. Kérem jelentkezzen be!");
        }
    }
}
