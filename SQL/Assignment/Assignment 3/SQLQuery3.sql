create database assignment3;
use assignment3;

 --table creation
create table dept (
    deptno int primary key,
    dname varchar(20),
    loc varchar(20)
);

create table emp (
    empno int primary key,
    ename varchar(20),
    job varchar(20),
    [mgr-id] int,
    hiredate date,
    sal int,
    [comm.] int,
    deptno int,
    foreign key (deptno) references dept(deptno)
);

--insert values
insert into dept values
(10,'accounting','new york'),
(20,'research','dallas'),
(30,'sales','chicago'),
(40,'operations','boston');

insert into emp values
(7369,'smith','clerk',7902,'1980-12-17',800,null,20),
(7499,'allen','salesman',7698,'1981-02-20',1600,300,30),
(7521,'ward','salesman',7698,'1981-02-22',1250,500,30),
(7566,'jones','manager',7839,'1981-04-02',2975,null,20),
(7654,'martin','salesman',7698,'1981-09-28',1250,1400,30),
(7698,'blake','manager',7839,'1981-05-01',2850,null,30),
(7782,'clark','manager',7839,'1981-06-09',2450,null,10),
(7788,'scott','analyst',7566,'1987-04-19',3000,null,20),
(7839,'king','president',null,'1981-11-17',5000,null,10),
(7844,'turner','salesman',7698,'1981-09-08',1500,0,30),
(7876,'adams','clerk',7788,'1987-05-23',1100,null,20),
(7900,'james','clerk',7698,'1981-12-03',950,null,30),
(7902,'ford','analyst',7566,'1981-12-03',3000,null,20),
(7934,'miller','clerk',7782,'1982-01-23',1300,null,10);

-- 1. Retrieve a list of MANAGERS. 
select * from emp where job = 'manager';

--2. Find out the names and salaries of all employees earning more than 1000 per month. 
select ename, sal from emp where sal > 1000;

-- 3. Display the names and salaries of all employees except JAMES. 
select ename, sal from emp where ename <> 'james';

--4. Find out the details of employees whose names begin with ‘S’.
select * from emp where ename like 's%';

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename from emp where ename like '%a%';

--6. Find out the names of all employees that have ‘L’ as their third character in their name. 
select ename from emp where ename like '__l%';

--7. Compute daily salary of JONES. 
select ename, sal/30 as daily_salary from emp where ename = 'jones';

--8. Calculate the total monthly salary of all employees. 
select sum(sal) as total_salary from emp;

--9. Print the average annual salary . 
select avg(sal*12) as avg_annual_salary from emp;

--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename, job, sal, deptno from emp
where job <> 'salesman' and deptno = 30;

--11. List unique departments of the EMP table. 
select distinct deptno from emp;

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as employee, sal as [monthly salary] from emp
where sal > 1500 and deptno in (10, 30);

--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename, job, sal from emp
where job in ('manager', 'analyst')
and sal not in (1000, 3000, 5000);

--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename, sal, [comm.] from emp
where [comm.] > sal * 1.10;

--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
select ename from emp
where ename like '%l%l%'
and (deptno = 30 or [mgr-id] = 7782);

--16. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
select ename, datediff(year, hiredate, getdate()) as experience from emp
where datediff(year, hiredate, getdate()) between 30 and 40;
select count(*) as total_employees from emp;

--17. Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename from dept d
join emp e on d.deptno = e.deptno
order by d.dname asc, e.ename desc;

--18. Find out experience of MILLER. 
select ename, datediff(year, hiredate, getdate()) as experience from emp
where ename = 'miller';