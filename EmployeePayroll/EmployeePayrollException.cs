using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    class EmployeePayrollException : Exception
    {
        public enum ExceptionType
        {
            COMPANY_NOT_FOUND,
            DEPT_NOT_FOUND,
            NO_EMP_NAME,
            WRONG_EMP_DETAILS,
            INVALID_DATE,
            EMP_ALREADY_ADDED
        }
        private ExceptionType type;
        public EmployeePayrollException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
