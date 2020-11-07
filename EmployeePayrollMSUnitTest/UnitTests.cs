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
    }
}
