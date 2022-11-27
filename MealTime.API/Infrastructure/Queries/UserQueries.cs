using MealTime.API.Infrastructure.DataObjects;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MealTime.API.Infrastructure.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly string _connectionString;
        public UserQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                    var result = await connection.QueryAsync<UserDto>(
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
