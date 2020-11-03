
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
name varchar(50) not null,
salary money not null,
start date not null
);
--gives the info about the table named employee_payroll
select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'employee_payroll';
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