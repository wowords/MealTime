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
        public async void Create(User user)
        {
            CheckIfExists(user.Email, user.UserName);  
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                //return NotFound();
            }
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAdminUsers()
        {
            return _context.Users.Where(x => x.IsAdmin == true);
        }

        public async Task<IEnumerable<User>> GettUsers()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
             _context.Users.Update(user);
             _context.SaveChanges();
        }
        private void CheckIfExists(string email, string username)
        {
            User user = _context.Users.Where(x => x.Email == email || x.UserName == username).FirstOrDefault();
            if (user == null)
                return null;
            else
                throw new MealTimeException("Az adott felhasználónév vagy email már használatban van. Kérem jelentkezzen be!");
        }
    }
}
