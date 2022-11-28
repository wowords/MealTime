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
                                 [Rating],
                                 [Category],
                                 [Details],
                                 [Type],
                                 [IsHealthy]
                        FROM [Foods]");
                return result;
            }
        }

        public async Task<IEnumerable<FoodDto>> GetTopRatedFoods()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<FoodDto>(
                    @"SELECT TOP 10 [Id],
                                 [Name],
                                 [Rating],
                                 [Category],
                                 [Details],
                                 [Type],
                                 [IsHealthy]
                        FROM [Foods] ORDER BY [Rating]");
                return result;
            }
        }
        public async Task<FoodDto> GetFoodById(int FoodId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<FoodDto>(
                    @"SELECT     [Name],
                                 [Recipe],
                                 [Rating],
                                 [Category],
                                 [Details],
                                 [Type],
                                 [IsHealthy]                                
                    FROM [Foods] WHERE [Id] = @FoodId",
                    new { FoodId });
                return result.FirstOrDefault();
            }
        }
    }
}
