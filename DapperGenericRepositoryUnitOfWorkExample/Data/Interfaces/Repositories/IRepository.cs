using System.Collections.Generic;
using System.Threading.Tasks;
using DapperGenericRepositoryUnitOfWorkExample.Data.Entities;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(long id, IConnectionContext context);
        Task<IEnumerable<T>> GetAll(IConnectionContext context);
        Task<T> Add(T entity, IConnectionContext context);
        Task Update(T entity, IConnectionContext context);
        Task Delete(T entity, IConnectionContext context);
    }
}
