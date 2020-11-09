using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    class EmployeePayrollException : Exception
    {
        public enum ExceptionType
        {
            NO_COMPANY_ID,
            NO_EMP_NAME
        }
        private ExceptionType type;
        public EmployeePayrollException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
