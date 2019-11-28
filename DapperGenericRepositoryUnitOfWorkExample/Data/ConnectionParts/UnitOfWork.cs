using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task BeginTransactionAsync()
        {
            try
            {
                _connection = new MySqlConnection(_connectionString);
                await _connection.OpenAsync();
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {
                _transaction.Dispose();
                _connection.Close();
                _connection.Dispose();
                throw;
            }
        }

        public void Commit()
        {
            _transaction.Commit();
            _connection.Close();
            _transaction.Dispose();
            _connection.Dispose();
        }

        public void RollBack()
        {
            _transaction.Rollback();
            _connection.Close();
            _transaction.Dispose();
            _connection.Dispose();
        }

        public IDbTransaction GetTransaction()
        {
            return _transaction;
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        private readonly string _connectionString;
        private MySqlTransaction _transaction;
        private MySqlConnection _connection;
    }
}
