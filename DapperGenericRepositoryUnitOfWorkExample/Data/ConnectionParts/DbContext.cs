using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using System;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class DbContext : IDbContext
    {
        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= _serviceProvider.GetRequiredService<IUserRepository>();
                return _userRepository;
            }
        }

        public DbContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly IServiceProvider _serviceProvider;

        private IUserRepository _userRepository;
    }
}
