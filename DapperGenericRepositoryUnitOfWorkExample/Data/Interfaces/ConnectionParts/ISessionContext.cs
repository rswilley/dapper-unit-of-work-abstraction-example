using System.Data;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts
{
    public interface ISessionContext : IConnectionContext
    {
        IDbConnection Connection { get; }
    }
}
