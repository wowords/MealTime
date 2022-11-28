using Dapper;
using MealTime.API.Infrastructure.DataObjects;
using MealTime.Models;
using MealTime.Models.Repository;
using Microsoft.Data.SqlClient;

namespace MealTime.API.Infrastructure.Queries
{
    public class MealQueries : IMealQueries
    {
        private readonly string _connectionString;
        public MealQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<Meal>> GetAllMeals()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Meal>(
                    @"SELECT [Id],
                                 [Rating],
                                 [LastOnMenu],
                                 [HasHealthyFood]
                        FROM [Meals]");
                return result;
            }
        }

        public async Task<IEnumerable<Meal>> GetTopRatedMeals()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Meal>(
                    @"SELECT TOP 10 [Id],
                                 [Rating],
                                 [LastOnMenu],
                                 [HasHealthyFood]
                        FROM [Meals] ORDER BY [Rating]");
                return result;
            }
        }
        public async Task<Meal> GetMealByid(int MealId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Meal>(
                    @"SELECT     [Id],
                                 [Rating],
                                 [LastOnMenu],
                                 [HasHealthyFood]
                        FROM [Meals] WHERE [Id] = @MealId",
                    new { MealId });
                return result.FirstOrDefault();
            }
        }        
    }
}
