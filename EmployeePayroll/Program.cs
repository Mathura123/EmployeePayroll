using System;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Assignment");
            Console.WriteLine("======================================");
            EmployeeRepo empObj = new EmployeeRepo();
            empObj.CheckConnection();
        }
    }
}
