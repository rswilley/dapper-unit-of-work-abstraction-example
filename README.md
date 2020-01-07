# dapper-unit-of-work-abstraction-example
Dapper Unit of Work with Generic Repository Example in C# and .NET Core 3.0

README is a work in progress

Create the MySQL test database

```
CREATE DATABASE /*!32312 IF NOT EXISTS*/`dapper_example` /*!40100 DEFAULT CHARACTER SET utf8 */;

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `EmailAddress` varchar(64) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `FirstName` varchar(48) NOT NULL,
  `LastName` varchar(48) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
```

Starting a transaction and writing data to the database 

```
//UnitOfWorkContext implements IDisposable. The default action is to rollback on error.
//Setting WasSuccessful to true will Commit the transaction when Dispose is called.
using (var unitOfWorkContext = await _storageManager.StartUnitOfWork()) {
  var newUser = await _storageManager.DbContext.UserRepository.Add(new User
  {
      EmailAddress = user.EmailAddress,
      Password = user.Password, //Never store passwords in plain text in a real world application
      FirstName = user.FirstName,
      LastName = user.LastName,
      CreatedDate = DateTime.UtcNow
  }, unitOfWorkContext);

  unitOfWorkContext.WasSuccessful = true; //Commits the transaction when Dispose is called
}
```

Opening a database connection and reading data from the database

```
//SessionContext implements IDisposable and will automatically close the
//database connection when Dispose is called
using (var sessionContext = await _storageManager.StartSession()) {
  var user = await _storageManager.DbContext.UserRepository.GetById(id, sessionContext);
}
```
