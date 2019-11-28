using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts;
using DapperGenericRepositoryUnitOfWorkExample.Data.Entities;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Repositories
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        public async Task<T> GetById(long id, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            return await parts.Connection.GetAsync<T>(id, parts.Transaction);
        }

        public async Task<IEnumerable<T>> GetAll(IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            return await parts.Connection.GetAllAsync<T>(parts.Transaction);
        }

        public async Task<T> Add(T entity, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            var id = await parts.Connection.InsertAsync(entity, parts.Transaction);

            entity.Id = id;
            return entity;
        }

        public async Task Update(T entity, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            await parts.Connection.UpdateAsync(entity, parts.Transaction);
        }

        public async Task Delete(T entity, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            await parts.Connection.DeleteAsync(entity, parts.Transaction);
        }

        public async Task<T> ReadSingleOrDefault(string query, object param, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            return await parts.Connection.QuerySingleOrDefaultAsync<T>(query, param, parts.Transaction);
        }

        public async Task<IEnumerable<T>> ReadMany(string query, object param, IConnectionContext context)
        {
            var parts = context.GetConnectionParts();
            return await parts.Connection.QueryAsync<T>(query, param, parts.Transaction);
        }

        public string GetColumns()
        {
            return ColumnBuilder<T>.GetColumns();
        }
    }
}
