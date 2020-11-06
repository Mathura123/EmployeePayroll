
--creates new database
create database payroll_service;
--gives the names of all the databases
SELECT name FROM sys.databases;
--selects the payroll_service database for use
use payroll_service;
--gives the name of database in use (now payroll_service)
select DB_NAME();

--creates table named employee_payroll in payroll_service database
create table employee_payroll
(
id int identity(1,1),
name varchar(150) not null,
salary money not null,
start date not null
);
--sets id as primary key
ALTER TABLE employee_payroll
ADD CONSTRAINT PK_ID PRIMARY KEY (id);
--gives the info about the table named employee_payroll
select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'employee_payroll';
exec sp_columns employee_payroll; 

--Insert datas in table employee_payroll
insert into employee_payroll values
('Bill',100000.00,'2018-01-03'),
('Terissa',200000.00,'2019-11-13'),
('Charlie',300000.00,'2020-05-21');

--retrives all datas in employee_payroll
select * from employee_payroll;

--to retrieve data of Bill's salary
select salary from employee_payroll where name = 'Bill';
--to retrieve datas of employees in between 2018-01-01 and today
select * from employee_payroll where start between '2018-01-01' and GETDATE();

--adds new column named 'gender'
alter table employee_payroll
add gender char;
--gives the info about the table named employee_payroll
select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'employee_payroll';
--set values of gender for Bill, Terissa and Charlie
update employee_payroll set gender = 'M' where name = 'Bill' or name = 'Charlie';
update employee_payroll set gender = 'F' where name = 'Terissa';
--retrives all datas in employee_payroll
select * from employee_payroll;

--retrives Sum, Average, Minimun, Maximum salaries and count for male and female 
select gender,SUM(salary) as 'Sum of Salaries', AVG(salary) as 'Average Salary', MIN(salary) as 'Minimum Salary', MAX(salary) as 'Maximum Salary', COUNT(gender) as 'Count' from employee_payroll
group by gender;

--adds column named 'phone' 
alter table employee_payroll add phone varchar(15);
--adds not nullable column named 'department' with default value ''
alter table employee_payroll add department varchar(50) not null default('');
--adds column named 'address' with default value 'India'
alter table employee_payroll add address varchar(150) default('India');

--renames salary column to basic_pay
EXEC sp_RENAME 'employee_payroll.salary', 'basic_pay', 'COLUMN';
--adds deductions column
alter table employee_payroll add deductions float;
--adds taxable_pay column
alter table employee_payroll add taxable_pay float;
--adds net_pay column
alter table employee_payroll add net_pay float;
--adds tax column
alter table employee_payroll add tax float;