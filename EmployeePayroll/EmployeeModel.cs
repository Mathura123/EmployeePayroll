namespace EmployeePayroll
{
    using System;

    public class EmployeeModel
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public int companyId { get; set; }
        public string companyName { get; set; }
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public char gender { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime startDate { get; set; }
        public decimal basicPay { get; set; }
        public decimal deductions { get; set; }
        public decimal taxablePay { get; set; }
        public decimal tax { get; set; }
        public decimal netPay { get; set; }
        /// <summary>Overrides to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return CustomPrint.PrintRow(employeeID.ToString(), employeeName, companyId.ToString(), companyName, departmentId.ToString(), departmentName, gender.ToString(), phoneNumber, address, startDate.ToShortDateString(), basicPay.ToString(), deductions.ToString(), taxablePay.ToString(), tax.ToString(), netPay.ToString());
        }
    }

}
