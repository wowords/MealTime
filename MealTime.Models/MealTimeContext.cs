using MealTime.Models;
using Microsoft.EntityFrameworkCore;

namespace MealTime.Models
{
    public class MealTimeContext : DbContext
    {
        public MealTimeContext()
        {
        }

        public MealTimeContext(DbContextOptions<MealTimeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;;Database=MealTime;Trusted_Connection = True; MultipleActiveResultSets = true";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
        }
    }

}