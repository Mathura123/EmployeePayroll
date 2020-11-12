using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll;
using System;

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
        [TestMethod]
        public void WhenGiven_DateRange_GetEmpInDateRange_ShouldReturn_True_IfConnectionProper_And_HasRows()
        {
            bool expected = true;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            bool result = empRepoObj.GetEmpInDateRange(Convert.ToDateTime("12/12/1996"), Convert.ToDateTime("12/12/2020"));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetAggValuesOfEmpByGender_ShouldReturn_True_IfConnectionProper_And_HasRows()
        {
            bool expected = true;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            bool result = empRepoObj.GetAggValuesOfEmpByGender();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WhenGiven_EmpModel_AddEmployee_ShouldReturn_True_IfConnectionProper_And_EmpAdded()
        {
            bool expected = true;
            EmployeeModel empModelObj = new EmployeeModel();
            empModelObj.employeeName = "Ruby";
            empModelObj.companyId = 2;
            empModelObj.address = "Dadar haveli, Pune";
            empModelObj.phoneNumber = null;
            empModelObj.gender = null;
            empModelObj.startDate = DateTime.Now;
            empModelObj.basicPay = 90000;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            bool result = empRepoObj.AddEmployee(empModelObj);
            Assert.AreEqual(expected, result);
        }
    }
}
