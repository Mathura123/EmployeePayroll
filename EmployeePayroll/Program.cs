namespace EmployeePayroll
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CustomPrint.PrintInRed("Welcome to Employee Payroll Assignment");
            Console.WriteLine("======================================");
            EmployeeRepo empObj = new EmployeeRepo();
            //empObj.CheckConnection();
            empObj.GetAllEmployee();
            //EmployeeModel modelObj = new EmployeeModel();
            //modelObj.employeeID = 2;
            //modelObj.basicPay = 195000;
            //modelObj.employeeName = "Terissa";
            //empObj.UpdateEmployeeSalary(modelObj);
            empObj.GetEmpByName("Terissa");
            empObj.GetEmpInDateRange(Convert.ToDateTime("12/12/1996"), Convert.ToDateTime("12/12/2020"));
            empObj.GetAggValuesOfEmpByGender();
        }
    }
}
