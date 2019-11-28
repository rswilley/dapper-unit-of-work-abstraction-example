using System.Data;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts
{
    public interface IConnectionSession
    {
        Task BeginSessionAsync();
        void EndSession();
        IDbConnection Connection { get; }
    }
}
