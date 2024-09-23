using System.Data;
using System.Data.SqlClient;


namespace WebApi05.Data
{
    public class SqlConnections
    { 
        private readonly string connectionString;
        public SqlConnections(string connectionString)
        {
            this.connectionString = connectionString;   
        }
        public async Task<IDbConnection> CreateConnectionAsync(SqlConnections connection)
        {
            
             var connect = new SqlConnection(connectionString);
            await connect.OpenAsync();
            return connect;
        }
    }
}
