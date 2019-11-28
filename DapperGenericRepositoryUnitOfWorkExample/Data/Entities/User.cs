using System;
using Dapper.Contrib.Extensions;

namespace DapperGenericRepositoryUnitOfWorkExample.Data.Entities
{
    [Table(TableConstants.User)]
    public class User : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
