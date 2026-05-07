create database assessment6
use assessment6

--1.Write a query to display your birthday(day of week)
SELECT DATENAME(WEEKDAY, '2003-08-15') AS DAY_OF_WEEK;

--2.Write a query to display your age in days
SELECT DATEDIFF(DAY, '2003-08-15', GETDATE()) AS AGE_IN_DAYS;

--3.Write a query to display all employees information those who joined before 5 years in the current month
--Create table
CREATE TABLE EMP (
    EMPNO INT,
    ENAME VARCHAR(50),
    JOB VARCHAR(30),
    SAL INT,
    HIREDATE DATE,
    DEPTNO INT);
 
 --Insert values
 INSERT INTO EMP VALUES
(101,'RAM','CLERK',1200,'2018-05-10',10),
(102,'RAJU','MANAGER',2500,'2019-05-15',20),
(103,'ANU','SALESMAN',1400,'2021-01-20',30),
(104,'SITA','ANALYST',3000,'2017-05-12',20);

--Query
SELECT * FROM EMP
WHERE HIREDATE < DATEADD(YEAR,-5,GETDATE())
AND MONTH(HIREDATE) = MONTH(GETDATE());

--4. Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--Create table
CREATE TABLE Employee (
    empno INT,
    ename VARCHAR(50),
    sal DECIMAL(10,2),
    doj DATE);

BEGIN TRANSACTION;
	--a. First insert 3 rows 
    INSERT INTO Employee VALUES (1, 'RAVI', 1000, GETDATE());
    INSERT INTO Employee VALUES (2, 'KIRAN', 2000, GETDATE());
    INSERT INTO Employee VALUES (3, 'ARUN', 3000, GETDATE());

	--b. Update the second row sal with 15% increment  
    UPDATE Employee
    SET sal = sal + (sal * 0.15)
    WHERE empno = 2;

    SAVE TRANSACTION AfterUpdate;

    --c. Delete first row.
    DELETE FROM Employee
    WHERE empno = 1;

    ROLLBACK TRANSACTION AfterUpdate;
    COMMIT TRANSACTION;
    SELECT * FROM Employee;

    --5.Create a user defined function calculate Bonus for all employees of a given dept using following conditions
    --Create table
    CREATE TABLE Emp_Info (
    empno INT,
    ename VARCHAR(50),
    sal DECIMAL(10,2),
    deptno INT);

    --Insert Values
    INSERT INTO Emp_Info VALUES (101,'SURIYA',1000,10);
    INSERT INTO Emp_Info VALUES (102,'PRIYA',2000,20);
    INSERT INTO Emp_Info VALUES (103,'GOUTHAM',1500,30);
    INSERT INTO Emp_Info VALUES (104,'HARISH',2500,10);

	--Create function
    CREATE FUNCTION dbo.CalculateBonus (@deptno INT, @sal DECIMAL(10,2))
    RETURNS DECIMAL(10,2)
    AS
    BEGIN
    DECLARE @bonus DECIMAL(10,2);
    IF @deptno = 10
        SET @bonus = @sal * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @sal * 0.20;
    ELSE
        SET @bonus = @sal * 0.05;
    RETURN @bonus;
END;

--Output
SELECT empno,ename,deptno,sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM Emp_Info;

--6.Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500
--Create table(Dept)
CREATE TABLE Dept (
    deptno INT,
    dname VARCHAR(50));
--Employee
CREATE TABLE Employee_Master (
    empno INT,
    ename VARCHAR(50),
    sal DECIMAL(10,2),
    deptno INT);

--Insert Values(Dept)
INSERT INTO Dept VALUES (10,'ACCOUNTING');
INSERT INTO Dept VALUES (20,'SALES');
INSERT INTO Dept VALUES (30,'HR');
--Employee
INSERT INTO Employee_Master VALUES (101,'PAVITHRA',1200,20);
INSERT INTO Employee_Master VALUES (102,'SARATH',1400,20);
INSERT INTO Employee_Master VALUES (103,'SWETHA',1600,10);
INSERT INTO Employee_Master VALUES (104,'ANCY',1000,20);

--Procedure
CREATE PROCEDURE Update_Sales_Employee_Salary
AS
BEGIN
    UPDATE Employee_Master
    SET sal = sal + 500
    WHERE deptno IN (
        SELECT deptno 
        FROM Dept
        WHERE dname = 'SALES'
     )
    AND sal < 1500;
END;

EXEC Update_Sales_Employee_Salary;
SELECT * FROM Employee_Master;

