using System;

namespace DapperGenericRepositoryUnitOfWorkExample.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
