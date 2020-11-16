namespace EmployeePayroll
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CustomPrint.PrintInRed("Welcome to Employee Payroll Assignment");
            Console.WriteLine("======================================");
            AskDetails.AskOptions();
        }
    }
}
