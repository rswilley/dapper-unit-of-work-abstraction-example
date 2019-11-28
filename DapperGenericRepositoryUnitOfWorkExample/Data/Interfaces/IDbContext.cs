using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces
{
    public interface IDbContext
    {
        IUserRepository UserRepository { get; }
    }
}
