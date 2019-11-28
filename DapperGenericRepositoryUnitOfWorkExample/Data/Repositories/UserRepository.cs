using System.Threading.Tasks;
using DapperGenericRepositoryUnitOfWorkExample.Data.Entities;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces.Repositories;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public async Task<User> GetByEmailAddress(string emailAddress, IConnectionContext context)
        {
            return await ReadSingleOrDefault($@"
                SELECT {GetColumns()} 
                FROM {Table} 
                WHERE {nameof(User.EmailAddress)} = @EmailAddress",
                new
                {
                    emailAddress
                }, context);
        }

        internal const string Table = TableConstants.User;
    }
}
