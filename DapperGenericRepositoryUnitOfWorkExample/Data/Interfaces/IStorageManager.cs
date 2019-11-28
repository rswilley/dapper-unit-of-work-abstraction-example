using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces
{
    public interface IStorageManager
    {
        Task<IConnectionContext> StartSession();
        Task<IConnectionContext> StartUnitOfWork();
        IDbContext DbContext { get; set; }
    }
}
