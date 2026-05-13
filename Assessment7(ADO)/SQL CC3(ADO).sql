CREATE DATABASE Employeemanagement;
USE Employeemanagement;

--1.
--Create table
CREATE TABLE Employee_Details
(
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2)
    CHECK (Empsal >= 25000),
    Emptype CHAR(1)
    CHECK (Emptype IN ('F','P')));

   --Procedure
    CREATE PROCEDURE sp_InsertEmployee
    (
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
    )
  AS
  BEGIN
    DECLARE @NewEmpNo INT;
    SELECT @NewEmpNo = ISNULL(MAX(Empno),1000) + 1
    FROM Employee_Details;
    INSERT INTO Employee_Details
    (
      Empno,EmpName,Empsal,Emptype
    )
    VALUES
    (
      @NewEmpNo,@EmpName,@Empsal,@Emptype
    );
END;

EXEC sp_InsertEmployee
    @EmpName = 'Dinesh',
    @Empsal = 35000,
    @Emptype = 'F';

EXEC sp_InsertEmployee
    @EmpName = 'Priya',
    @Empsal = 28000,
    @Emptype = 'P';

SELECT * FROM Employee_Details;

USE Employeemanagement;
CREATE USER [INFICS\suriyasa]
FOR LOGIN [INFICS\suriyasa];
ALTER ROLE db_owner
ADD MEMBER [INFICS\suriyasa];

--2.
--Procedure
CREATE PROCEDURE sp_UpdateSalary
(
    @Empid INT,
    @UpdatedSalary NUMERIC(10,2) OUTPUT
)
AS
BEGIN
    UPDATE Employee_Details
    SET Empsal = Empsal + 100
    WHERE Empno = @Empid;
    SELECT @UpdatedSalary = Empsal
    FROM Employee_Details
    WHERE Empno = @Empid;
END;

