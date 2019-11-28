using System.Data;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.ConnectionParts
{
    public class ConnectionParts
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
    }
}
