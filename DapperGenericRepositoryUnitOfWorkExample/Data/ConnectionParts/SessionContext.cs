using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.ConnectionParts;
using System.Data;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class SessionContext : ISessionContext
    {
        public IDbConnection Connection { get; }
        public bool WasSuccessful { get; set; }

        public SessionContext(IConnectionSession session)
        {
            _session = session;
            Connection = session.Connection;
        }

        public void Dispose()
        {
            _session.EndSession();
        }

        private readonly IConnectionSession _session;
    }
}
