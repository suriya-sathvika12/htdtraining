CREATE DATABASE ContactDb;
USE ContactDb;

CREATE TABLE Contacts
(
    Id BIGINT PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(150)
);

CREATE USER [INFICS\suriyasa] FOR LOGIN [INFICS\suriyasa];
ALTER ROLE db_owner ADD MEMBER [INFICS\suriyasa];

