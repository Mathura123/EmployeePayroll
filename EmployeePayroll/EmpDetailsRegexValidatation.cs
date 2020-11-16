using System.Text.RegularExpressions;

namespace EmployeePayroll
{
    class EmpDetailsRegexValidatation
    {
        private static string regexPhoneNo = @"^(\+\d{1,3}[- ]?)?[1-9]\d{9}$";
        private static string regexGender = @"^[MFmf\s]{0,1}$";
        public static bool ValidatePhoneNo(string phoneNo)
        {
            if (Regex.IsMatch(phoneNo, regexPhoneNo))
                return true;
            throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.INVALID_PHONE_NO, "Invalid Phone No");
        }
        public static bool ValidateGender(string gender)
        {
            if (Regex.IsMatch(gender, regexGender))
                return true;
            throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.INVALID_GENDER, "Invalid Gender");
        }
    }
}
