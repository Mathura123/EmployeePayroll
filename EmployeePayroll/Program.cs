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
            EmployeeModel modelObj = new EmployeeModel();
            modelObj.companyId = 2;
            modelObj.gender = null;
            modelObj.employeeName = "Tommy";
            modelObj.phoneNumber = null;
            modelObj.address = null;
            modelObj.startDate = Convert.ToDateTime("12/10/1997");
            modelObj.basicPay = 8000;
            //empObj.UpdateEmployeeSalary(modelObj);
            empObj.GetEmpByName("Terissa");
            empObj.GetEmpInDateRange(Convert.ToDateTime("12/12/1996"), Convert.ToDateTime("12/12/2020"));
            empObj.GetAggValuesOfEmpByGender();
            empObj.AddEmployee(modelObj);
        }
    }
}
