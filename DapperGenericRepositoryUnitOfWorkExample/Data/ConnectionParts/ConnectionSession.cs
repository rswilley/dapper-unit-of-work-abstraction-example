using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class ConnectionSession : IConnectionSession
    {
        public ConnectionSession(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task BeginSessionAsync()
        {
            try
            {
                _connection = new MySqlConnection(_connectionString);
                await _connection.OpenAsync();
            }
            catch (Exception)
            {
                _connection.Close();
                _connection.Dispose();

                throw;
            }
        }

        public void EndSession()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public IDbConnection Connection => _connection;

        private readonly string _connectionString;
        private MySqlConnection _connection;
    }
}
