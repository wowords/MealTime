using MealTime.Models;

namespace MealTime.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MealTimeContext _context;
        public UserRepository(MealTimeContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
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

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users.Where(x => x.IsAdmin == true).ToList();
        }

        public IEnumerable<User> GettUsers()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
             _context.Users.Update(user);
             _context.SaveChanges();

        }
    }
}
