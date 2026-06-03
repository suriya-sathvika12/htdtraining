CREATE DATABASE MoviesDB
USE MoviesDB

SELECT * FROM Movies;

DECLARE @Year INT = 1999;
SELECT * FROM Movies
WHERE YEAR(DateOfRelease) = @Year;

DECLARE @DirectorName VARCHAR(100) = 'rajamouli';
SELECT * FROM Movies
WHERE LOWER(DirectorName) = LOWER(@DirectorName);

CREATE USER [INFICS\suriyasa] FOR LOGIN [INFICS\suriyasa];
ALTER ROLE db_owner ADD MEMBER [INFICS\suriyasa];