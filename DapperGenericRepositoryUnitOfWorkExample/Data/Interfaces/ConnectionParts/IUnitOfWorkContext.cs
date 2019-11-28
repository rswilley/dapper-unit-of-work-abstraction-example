using System.Data;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts
{
    public interface IUnitOfWorkContext : IConnectionContext
    {
        IDbTransaction Transaction { get; }
    }
}
