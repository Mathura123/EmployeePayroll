
--creates new database
create database payroll_service;
--gives the names of all the databases
SELECT name FROM sys.databases;
--selects the payroll_service database for use
use payroll_service;
--gives the name of database in use (now payroll_service)
select DB_NAME();