create database assignment2;
use assignment2;

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

-- 1. list all employees whose name begins with 'a'. 
select * from emp where ename like 'a%';

--2. select all those employees who don't have a manager. 
select * from emp where [mgr-id] is null;

--3. list employee name, number and salary for those employees who earn in the range 1200 to 1400.
select ename, empno, sal 
from emp 
where sal between 1200 and 1400;

--4. give all the employees in the research department a 10% pay rise. verify that this has been done by listing all their details before and after the rise. 
--before
select * from emp where deptno = 20;
update emp 
set sal = sal * 1.10
where deptno = 20;
--after
select * from emp where deptno = 20;

--5. find the number of clerks employed. give it a descriptive heading. 
select count(*) as no_of_clerks
from emp
where job = 'clerk';

--6. find the average salary for each job type and the number of people employed in each job. 
select job, avg(sal) as avg_salary, count(*) as total_employees
from emp
group by job;

--7. list the employees with the lowest and highest salary. 
select * from emp 
where sal = (select min(sal) from emp) or sal = (select max(sal) from emp);

--8. list full details of departments that don't have any employees. 
select * from dept
where deptno not in (select distinct deptno from emp);

--9. get the names and salaries of all the analysts earning more than 1200 who are based in department 20. sort the answer by ascending order of name. 
select ename, sal 
from emp
where job = 'analyst' 
and sal > 1200 
and deptno = 20
order by ename asc;

--10. for each department, list its name and number together with the total salary paid to employees in that department. 
select d.deptno, d.dname, sum(e.sal) as total_salary
from dept d
left join emp e on d.deptno = e.deptno
group by d.deptno, d.dname;

--11. find out salary of both miller and smith.
select ename, sal 
from emp 
where ename in ('miller','smith');

--12. find out the names of the employees whose name begin with ‘a’ or ‘m’. 
select * from emp 
where ename like 'a%' or ename like 'm%';

--13. compute yearly salary of smith. 
select ename, sal*12 as yearly_salary
from emp 
where ename = 'smith';

--14. list the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename, sal 
from emp
where sal not between 1500 and 2850;

--15. find all managers who have more than 2 employees reporting to them
select [mgr-id], count(*) as employee_count
from emp
where [mgr-id] is not null
group by [mgr-id]
having count(*) > 2;


