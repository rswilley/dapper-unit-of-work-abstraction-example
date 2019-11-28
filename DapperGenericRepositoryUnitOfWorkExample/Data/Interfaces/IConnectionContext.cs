using System;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces
{
    public interface IConnectionContext : IDisposable
    {
        bool WasSuccessful { get; set; }
    }
}
