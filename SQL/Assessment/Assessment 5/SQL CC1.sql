create database Assessment5;
use Assessment5;
-- 1. 
Create table books (
id int primary key,
title varchar(100),
author varchar(100),
isbn bigint unique,
published_date Datetime );

Insert into books values
(1,'My First SQL book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL book','Cory Flint',523120967812,'2015-10-18 14:05:44');

-- 1.Write a query to fetch the details of the books written by author whose name ends with er.
    Select * from books where author LIKE '%er';

    --2.
    Create table reviews(
    id int primary key,
    book_id int,
    reviewer_name varchar(100),
    content varchar(255),
    rating int,
    published_date datetime,
    foreign key (book_id)references books(id) );

    insert into reviews values
    (1,1,'John Smith','My first review',4,'2017-12-10 05:50:11'),
    (2,2,'John Smith','My second review',5,'2017-10-13 15:05:12'),
    (3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10');

-- 2.Display the Title ,Author and ReviewerName for all the books from the above table  
select b.title,b.author,r.reviewer_name from books b join reviews r on b.id = r.book_id;


-- 3.Display the  reviewer name who reviewed more than one book. 
select reviewer_name from reviews
group by reviewer_name
having count(distinct book_id) > 1;

--4.
Create table customers (
id int,
name varchar(100),
age int,
address varchar(100),
salary decimal(10,2));

insert into customers values
(1,'Ramesh',32,'Ahmedabed',2000),
(2,'Khilan',25,'Delhi',1500),
(3,'Kaushik',23,'Kota',2000),
(4,'Chaitali',25,'Mumbai',6500),
(5,'Hardik',27,'Bhopal',8500),
(6,'Komal',22,'MP',4500),
(7,'Muffy',24,'Indore',10000);


 -- 4.Display the Name for the customer from above customer table who live in same address which has character o anywhere in address 
 select name from customers where address like '%o%';

 --5.
 create table orders (
 order_id int,
 order_date datetime,
 customer_id int,
 amount int);

 insert into orders values 
 (102,'2009-10-08',3,3000),
 (100,'2009-10-08',3,1500),
 (101,'2009-11-20',2,1560),
 (103,'2008-15-20',4,2060);

 -- 5.Write a query to display the Date,Total no of customer  placed order on same Date  
 select order_date, count (distinct customer_id) as total_customers from orders group by order_date;

 --6.
 create table Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Address VARCHAR(100),
    Salary DECIMAL(10,2)
);
 
INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', NULL),
(7, 'Muffy', 24, 'Indore', NULL);
 
--6.Display the Names of the Employee in lower case, whose salary is null  
SELECT LOWER(Name) AS EmployeeName FROM Employee
WHERE Salary IS NULL;
 
-- 7.
CREATE TABLE Studentdetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(20),
    MobileNo BIGINT,
    Mail_id VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1));
 
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M');
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M');
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(4, 'Selvi', 22, 'B.Tech', 8904567342, 'selvi@gmail.com', 'Selam', 'F');
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F');
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(6, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F');
INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');

 -- 7.Write a sql server query to display the Gender,Total no of male and female from the above relation    . 
SELECT Gender,COUNT(*) AS TotalCount
FROM Studentdetails
GROUP BY Gender;
 

 

