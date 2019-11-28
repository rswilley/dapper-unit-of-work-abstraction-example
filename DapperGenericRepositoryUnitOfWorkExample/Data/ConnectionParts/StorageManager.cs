using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class StorageManager : IStorageManager
    {
        public StorageManager(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            DbContext = new DbContext(serviceProvider);
        }

        public async Task<IConnectionContext> StartSession()
        {
            var session = _serviceProvider.GetRequiredService<IConnectionSession>();
            await session.BeginSessionAsync();
            return new SessionContext(session);
        }

        public async Task<IConnectionContext> StartUnitOfWork()
        {
            var unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
            await unitOfWork.BeginTransactionAsync();
            return new UnitOfWorkContext(unitOfWork);
        }

        public IDbContext DbContext { get; set; }

        private readonly IServiceProvider _serviceProvider;
    }
}
