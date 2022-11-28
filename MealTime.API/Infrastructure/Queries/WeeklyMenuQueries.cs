using Dapper;
using MealTime.API.Infrastructure.DataObjects;
using Microsoft.Data.SqlClient;

namespace MealTime.API.Infrastructure.Queries
{
    public class WeeklyMenuQueries : IWeeklyMenuQueries
    {
        private readonly string _connectionString;
        public WeeklyMenuQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<WeeklyMenuDto>> GetAllMenus()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<WeeklyMenuDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }

        public async Task<IEnumerable<WeeklyMenuDto>> GetTopRatedMenus()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<WeeklyMenuDto>(
                    @"SELECT [Id],
                                 [Name],
                                 [Username],
                                 [IsAdmin]
                        FROM [Users]");
                return result;
            }
        }
        public async Task<WeeklyMenuDto> GetMenuById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<WeeklyMenuDto>(
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
