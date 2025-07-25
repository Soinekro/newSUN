using Dapper;
using RRHHService.API.Infrastructure.Persistence;
using System.Data;

namespace RRHHService.API.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public UserRepository(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> AuthenticateUserAsync(string connectionString, string username, string password)
        {
            using var connection = _connectionFactory.CreateConnection(connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Username", username);
            parameters.Add("@Password", password);

            var result = await connection.ExecuteScalarAsync<int>(
                "AuthenticateUserProcedure", 
                parameters, 
                commandType: CommandType.StoredProcedure
            );

            return result == 1; // Assuming the procedure returns 1 for success
        }
    }
}
