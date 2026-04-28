create database assignment4;
use assignment4;

--1.	Write a T-SQL Program to find the factorial of a given number.
DECLARE @num INT = 5;   
DECLARE @fact BIGINT = 1;
DECLARE @i INT = 1;
WHILE @i <= @num
BEGIN
    SET @fact = @fact * @i;
    SET @i = @i + 1;
END
PRINT 'Factorial is: ' + CAST(@fact AS VARCHAR);


--2.	Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
CREATE PROCEDURE sp_MultiplicationTable
    @num INT,
    @limit INT
AS
BEGIN
    DECLARE @i INT = 1;
    WHILE @i <= @limit
    BEGIN
        PRINT CAST(@num AS VARCHAR) + ' x ' + 
              CAST(@i AS VARCHAR) + ' = ' + 
              CAST(@num * @i AS VARCHAR);
        SET @i = @i + 1;
    END
END;

EXEC sp_MultiplicationTable 5, 10;


--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

--Function
CREATE FUNCTION fn_GetStatus (@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @result VARCHAR(10);

    IF @score >= 50
        SET @result = 'Pass';
    ELSE
        SET @result = 'Fail';
    RETURN @result;
END;

--Table creation
create table student (
    sid int primary key,
    sname varchar(20));

create table marks (
    mid int primary key,
    sid int,
    score int,
    foreign key (sid) references student(sid));

--Inserting values
INSERT INTO Student VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

INSERT INTO Marks VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

--Display data
select s.sid,s.sname,m.score,dbo.fn_getstatus(m.score) as status
from student s
join marks m on s.sid = m.sid
order by s.sid;



