using Microsoft.Data.SqlClient;
using System.Data;

namespace RRHHService.API.Infrastructure.Persistence
{
    public class DatabaseConnectionFactory
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
