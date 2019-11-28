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
