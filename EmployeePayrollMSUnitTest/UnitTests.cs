using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayroll;
using System;
using System.Collections.Generic;

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
            empModelObj.companyName = "Company2";
            empModelObj.address = "Dadar haveli, Pune";
            empModelObj.departmentName = new string[] { "HR" };
            empModelObj.phoneNumber = null;
            empModelObj.gender = null;
            empModelObj.startDate = DateTime.Now;
            empModelObj.basicPay = 90000;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            bool result = empRepoObj.AddEmployee(empModelObj);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WhenGiven_EmpNameCompanyNameDeptName_DeleteEmployee_ShouldReturn_True_IfConnectionProper_And_EmpDeleted()
        {
            bool expected = true;
            EmployeeModel objModel = new EmployeeModel();
            objModel.employeeName = "Terissa";
            objModel.companyName = "Company1";
            objModel.departmentName = new string[] { "Sales", "HR", "hj" };
            EmployeeRepo objRepo = new EmployeeRepo();
            bool result = objRepo.DeleteEmployee(objModel.employeeName, objModel.companyName, objModel.departmentName);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void WhenGiven_EmpModelList_To_AddMultipleEmployee_Should_Add_MultipleEmp()
        {
            List<EmployeeModel> empModelList = new List<EmployeeModel>
            {
                new EmployeeModel(){ employeeName ="Bruce", companyName = "Company1" ,departmentName = new string[]{"HR" }, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Banner", companyName = "Company2" ,departmentName = new string[]{"HR","Sales" }, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="clark", companyName = "Company2" ,departmentName = new string[]{"HR","Enigineering" }, gender = "M",phoneNumber= "9999999999", address = null, startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Mike", companyName = "Company1" ,departmentName = new string[]{"HR"}, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Jason", companyName = "Company3" ,departmentName = new string[]{"Marketing","Sales" }, gender = null,phoneNumber= "9999999999", address = null, startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
        };
            EmployeeRepo empRepoObj = new EmployeeRepo();
            DateTime startDateTimeThread = DateTime.Now;
            empRepoObj.AddMultipleEmployee(empModelList);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (startDateTimeThread - stopDateTimeThread));
        }
        [TestMethod]
        public void WhenGiven_EmpModelList_To_AddMultipleEmployeeWithThread_Should_Add_MultipleEmp()
        {
            List<EmployeeModel> empModelList = new List<EmployeeModel>
            {
                new EmployeeModel(){ employeeName ="Hardy", companyName = "Company2" ,departmentName = new string[]{"HR" }, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Berlin", companyName = "Company1" ,departmentName = new string[]{"HR","Sales" }, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Jimmy", companyName = "Company2" ,departmentName = new string[]{"HR","Engineering" }, gender = "M",phoneNumber= "9999999999", address = null, startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Rupa", companyName = "Company1" ,departmentName = new string[]{"HR"}, gender = "M",phoneNumber= "9999999999", address = "xyz", startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
                new EmployeeModel(){ employeeName ="Jason", companyName = "Company3" ,departmentName = new string[]{"Marketing","Sales" }, gender = null,phoneNumber= "9999999999", address = null, startDate = Convert.ToDateTime("12/09/2017"), basicPay= 10000},
        };
            DateTime startDateTime = DateTime.Now;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            empRepoObj.AddMultipleEmployeeWithThread(empModelList);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (startDateTime - stopDateTime));
        }
    }
}
