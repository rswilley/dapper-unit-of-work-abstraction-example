using System.Threading.Tasks;
using DapperGenericRepositoryUnitOfWorkExample.Data.Entities;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAddress(string emailAddress, IConnectionContext context);
    }
}
