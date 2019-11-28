using System.Data;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        void Commit();
        void RollBack();
        
        IDbTransaction GetTransaction();
        IDbConnection GetConnection();
    }
}
