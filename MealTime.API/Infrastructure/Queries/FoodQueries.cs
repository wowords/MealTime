using Dapper;
using MealTime.API.Infrastructure.DataObjects;
using Microsoft.Data.SqlClient;

namespace MealTime.API.Infrastructure.Queries
{
    public class FoodQueries : IFoodQueries
    {
        private readonly string _connectionString;
        public FoodQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<FoodDto>> GetAllFoods()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<FoodDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }

        public async Task<IEnumerable<FoodDto>> GetTopRatedFoods()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<FoodDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }
        public async Task<FoodDto> GetFoodById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<FoodDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result.FirstOrDefault();
            }
        }
    }
}
