namespace EmployeePayroll
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Assignment");
            Console.WriteLine("======================================");
            EmployeeRepo empObj = new EmployeeRepo();
            //empObj.CheckConnection();
            empObj.GetAllEmployee();
            EmployeeModel modelObj = new EmployeeModel();
            modelObj.employeeID = 2;
            modelObj.basicPay = 195000;
            modelObj.employeeName = "Terissa";
            empObj.UpdateEmployeeSalary(modelObj);
        }
    }
}
