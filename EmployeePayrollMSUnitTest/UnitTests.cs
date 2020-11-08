using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll;

namespace EmployeePayrollMSUnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void WhenValidConnectionString_CheckConnetion_ShouldReturn_True()
        {
            bool expected = true;
            EmployeeRepo empTestObj = new EmployeeRepo();
            bool result = empTestObj.CheckConnection();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WnenGiven_EmployeeModelObj_UpdateEmployeeSalary_ShouldReturn_True_AfterDoingUpdate()
        {
            bool expected = true;
            EmployeeModel empModelObj = new EmployeeModel();
            empModelObj.employeeName = "Bill";
            empModelObj.basicPay = 300000;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            bool result = empRepoObj.UpdateEmployeeSalary(empModelObj);
            Assert.AreEqual(expected, result);
        }
    }
}
