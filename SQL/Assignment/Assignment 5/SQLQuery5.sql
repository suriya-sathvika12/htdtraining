create database assignment5;
use assignment5;

-- 1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
--Table Creation
CREATE TABLE EMP (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    Salary DECIMAL(10,2)
);

--Inserting values 
INSERT INTO EMP VALUES (1, 'Ravi Kumar', 30000);
INSERT INTO EMP VALUES (2, 'Anjali', 40000);
INSERT INTO EMP VALUES (3, 'Suresh', 35000);

CREATE PROCEDURE GeneratePayslip
    @EmpID INT
AS
BEGIN
    DECLARE 
        @EmpName VARCHAR(50),
        @Salary DECIMAL(10,2),
        @HRA DECIMAL(10,2),
        @DA DECIMAL(10,2),
        @PF DECIMAL(10,2),
        @IT DECIMAL(10,2),
        @Deductions DECIMAL(10,2),
        @GrossSalary DECIMAL(10,2),
        @NetSalary DECIMAL(10,2);

    -- Fetch employee details
    SELECT 
        @EmpName = EmpName,
        @Salary = Salary
    FROM EMP
    WHERE EmpID = @EmpID;

    -- Calculations
    SET @HRA = @Salary * 0.10;
    SET @DA = @Salary * 0.20;
    SET @PF = @Salary * 0.08;
    SET @IT = @Salary * 0.05;

    SET @Deductions = @PF + @IT;
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @NetSalary = @GrossSalary - @Deductions;

    -- Print Payslip
    PRINT '-----------------------------';
    PRINT '         PAYSLIP             ';
    PRINT '-----------------------------';
    PRINT 'Employee ID   : ' + CAST(@EmpID AS VARCHAR);
    PRINT 'Employee Name : ' + @EmpName;
    PRINT 'Basic Salary  : ' + CAST(@Salary AS VARCHAR);

    PRINT '----- Earnings -----';
    PRINT 'HRA (10%)      : ' + CAST(@HRA AS VARCHAR);
    PRINT 'DA (20%)       : ' + CAST(@DA AS VARCHAR);

    PRINT '----- Deductions -----';
    PRINT 'PF (8%)        : ' + CAST(@PF AS VARCHAR);
    PRINT 'IT (5%)        : ' + CAST(@IT AS VARCHAR);
    PRINT 'Total Deduction: ' + CAST(@Deductions AS VARCHAR);

    PRINT '-----------------------------';
    PRINT 'Gross Salary   : ' + CAST(@GrossSalary AS VARCHAR);
    PRINT 'Net Salary     : ' + CAST(@NetSalary AS VARCHAR);
    PRINT '-----------------------------';
END;

EXEC GeneratePayslip @EmpID = 1;

--Question 2

--Table Creation
CREATE TABLE Holiday (
    Holiday_Date DATE,
    Holiday_Name VARCHAR(50)
);

--Inserting values
INSERT INTO Holiday VALUES ('2026-01-26', 'Republic Day');
INSERT INTO Holiday VALUES ('2026-08-15', 'Independence Day');
INSERT INTO Holiday VALUES ('2026-10-24', 'Diwali');
INSERT INTO Holiday VALUES ('2026-12-25', 'Christmas');

--Trigger
CREATE TRIGGER trg_PreventManipulationOnHoliday
ON EMP
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Today DATE;
    DECLARE @HolidayName VARCHAR(50);
    SET @Today = CAST(GETDATE() AS DATE);
    SELECT @HolidayName = Holiday_Name
    FROM Holiday
    WHERE Holiday_Date = @Today;
    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR ('Due to %s you cannot manipulate data', 16, 1, @HolidayName);
        ROLLBACK TRANSACTION;
    END
END;
