
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