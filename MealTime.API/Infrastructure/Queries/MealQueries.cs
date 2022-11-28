using Dapper;
using MealTime.API.Infrastructure.DataObjects;
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
        public async Task<IEnumerable<MealDto>> GetAllMeals()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<MealDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }

        public async Task<IEnumerable<MealDto>> GetTopRatedMeals()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<MealDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }
        public async Task<MealDto> GetMealByid(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<MealDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<MealDto>> GetAllMeals()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<MealDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }

    }
}
