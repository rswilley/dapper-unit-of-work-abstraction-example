using DapperGenericRepositoryUnitOfWorkExample.Data.Entities;
using DapperGenericRepositoryUnitOfWorkExample.Data.Interfaces;
using DapperGenericRepositoryUnitOfWorkExample.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DapperGenericRepositoryUnitOfWorkExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //In a real world project you would not use StorageManager in a Controller
        //You may have a service layer or something similar, but that is out of the scope of this example
        public UserController(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            //UnitOfWorkContext implements IDisposable. The default action is to rollback on error.
            //Setting WasSuccessful to true will Commit the transaction when Dispose is called.
            using var unitOfWorkContext = await _storageManager.StartUnitOfWork();
            var newUser = await _storageManager.DbContext.UserRepository.Add(new User
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password, //Never store passwords in plain text in a real world application
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = DateTime.UtcNow
            }, unitOfWorkContext);

            unitOfWorkContext.WasSuccessful = true; //Commits the transaction when Dispose is called

            return Created("", newUser.Id);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            //SessionContext implements IDisposable and will automatically close the
            //database connection when Dispose is called
            using var sessionContext = await _storageManager.StartSession();
            var user = await _storageManager.DbContext.UserRepository.GetById(id, sessionContext);
            if (user == null)
                return NotFound();

            //Never send the password to the client
            //In a real world project you may use something like AutoMapper to map properties
            return Ok(new UserDto
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate
            });
        }

        [HttpGet]
        [Route("{emailAddress}")]
        public async Task<IActionResult> GetByEmailAddress(string emailAddress)
        {
            //SessionContext implements IDisposable and will automatically close the
            //database connection when Dispose is called
            using var sessionContext = await _storageManager.StartSession();
            var user = await _storageManager.DbContext.UserRepository.GetByEmailAddress(emailAddress, sessionContext);
            if (user == null)
                return NotFound();

            //Never send the password to the client
            //In a real world project you may use something like AutoMapper to map properties
            return Ok(new UserDto
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate
            });
        }

        private readonly IStorageManager _storageManager;
    }
}
