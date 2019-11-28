using System;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public static class ConnectionContextExtensions
    {
        public static ConnectionParts GetConnectionParts(this IConnectionContext context)
        {
            return context switch
            {
                IUnitOfWorkContext unitOfWorkContext => new ConnectionParts
                {
                    Connection = unitOfWorkContext.Transaction.Connection,
                    Transaction = unitOfWorkContext.Transaction
                },
                ISessionContext sessionContext => new ConnectionParts
                {
                    Connection = sessionContext.Connection, 
                    Transaction = null
                },
                _ => throw new NotSupportedException()
            };
        }
    }
}
