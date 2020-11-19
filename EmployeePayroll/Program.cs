namespace EmployeePayroll
{
    using System;
    using System.Collections.Generic;

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
