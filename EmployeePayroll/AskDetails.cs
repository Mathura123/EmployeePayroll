namespace EmployeePayroll
{
    using System;

    public class AskDetails
    {
        public static void AskOptions()
        {
            Console.WriteLine("Enter 1 : Get all Employees details\n" +
                "Enter 2 : Get Employee details by name\n" +
                "Enter 3 : Get all employee details started the given period\n" +
                "Enter 4 : Get Aggregate Values by gender\n" +
                "Enter 5 : Update Employee salary\n" +
                "Enter 6 : Add an Employee\n" +
                "Enter 7 : Delete an Employee\n" +
                "Enter 8 : Exit");
            try
            {
                Console.Write("Your Entry : ");
                int key = Convert.ToInt32(Console.ReadLine());
                ActionOnKey(key);
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                AskOptions();
            }
        }
        private static void ActionOnKey(int key)
        {
            EmployeeRepo empObj = new EmployeeRepo();
            switch (key)
            {
                case 1:
                    empObj.GetAllEmployee();
                    AskOptions();
                    break;
                case 2:
                    empObj.GetEmpByName(AskName());
                    AskOptions();
                    break;
                case 3:
                    DateTime[] dates = AskDates();
                    empObj.GetEmpInDateRange(dates[0], dates[1]);
                    AskOptions();
                    break;
                case 4:
                    empObj.GetAggValuesOfEmpByGender();
                    AskOptions();
                    break;
                case 5:
                    empObj.UpdateEmployeeSalary(AskDetailsToUpdate());
                    AskOptions();
                    break;
                case 6:
                    empObj.AddEmployee(AskEmployeeDetailsToAdd());
                    AskOptions();
                    break;
                case 7:
                    EmployeeModel objModel = AskDetailsToDelete();
                    empObj.DeleteEmployee(objModel.employeeName, objModel.companyName, objModel.departmentName);
                    AskOptions();
                    break;
                default:
                    break;
            }
        }
        private static string AskName()
        {
            Console.Write("Enter the name of employee : ");
            return Console.ReadLine();
        }
        private static DateTime[] AskDates()
        {
            DateTime[] dates = new DateTime[2];
            try
            {
                Console.Write("Enter the start date in DD/MM/YYYY format : ");
                dates[0] = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter the end date in DD/MM/YYYY format : ");
                dates[1] = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.INVALID_DATE, "Invalid Date");
            }
            return dates;
        }
        private static EmployeeModel AskEmployeeDetailsToAdd()
        {
            EmployeeModel objEmpModel = new EmployeeModel();
            Console.Write("Enter the Employee Name : ");
            objEmpModel.employeeName = Console.ReadLine();
            Console.Write("Enter the Company Name : ");
            objEmpModel.companyName = Console.ReadLine();
            Console.Write("Enter departments names separated by commas(Eg. Marketing,HR) : ");
            objEmpModel.departmentName = Console.ReadLine().Split(',');
        label1:
            Console.Write("Enter the gender : ");
            string gender = Console.ReadLine();
            try
            {
                if (EmpDetailsRegexValidatation.ValidateGender(gender))
                    objEmpModel.gender = gender.ToUpper();
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                goto label1;
            }
        label2:
            Console.Write("Enter the Phone Number : ");
            string phoneNumber = Console.ReadLine();
            try
            {
                if (EmpDetailsRegexValidatation.ValidatePhoneNo(phoneNumber))
                    objEmpModel.phoneNumber = phoneNumber;
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                goto label2;
            }
            Console.Write("Enter the address : ");
            objEmpModel.address = Console.ReadLine();
        label3:
            Console.Write("Enter the start date in DD/MM/YYYY format : ");
            try
            {
                objEmpModel.startDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                goto label3;
            }
            Console.Write("Enter the basic pay : ");
            objEmpModel.basicPay = Convert.ToDecimal(Console.ReadLine());
            return objEmpModel;
        }
        private static EmployeeModel AskDetailsToUpdate()
        {
            try
            {
                EmployeeModel objEmpModel = new EmployeeModel();
                Console.Write("Enter the Employee Name : ");
                objEmpModel.employeeName = Console.ReadLine();
                Console.Write("Enter the new basic pay : ");
                objEmpModel.basicPay = Convert.ToDecimal(Console.ReadLine());
                return objEmpModel;
            }
            catch
            {
                throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.WRONG_EMP_DETAILS, "Wrong details");
            }
        }
        private static EmployeeModel AskDetailsToDelete()
        {
            EmployeeModel objEmpModel = new EmployeeModel();
            Console.Write("Enter the Employee Name : ");
            objEmpModel.employeeName = Console.ReadLine();
            Console.Write("Enter the Company Name : ");
            objEmpModel.companyName = Console.ReadLine();
            Console.Write("Enter departments names separated by commas(Eg. Marketing,HR) : ");
            objEmpModel.departmentName = Console.ReadLine().Split(',');
            return objEmpModel;
        }
    }
}
