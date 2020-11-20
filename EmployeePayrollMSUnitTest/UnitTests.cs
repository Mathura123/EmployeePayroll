namespace EmployeePayrollMSUnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EmployeePayroll;
    using System;
    using System.Collections.Generic;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

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
        [TestMethod]
        public void WhenGiven_EmpModelList_To_UpdateMultipleEmployeeSalary_Should_UpadteSalary_For_MultipleEmp()
        {
            List<EmployeeModel> empModelList = new List<EmployeeModel>
            {
                new EmployeeModel(){ employeeName ="Hardy",basicPay= 20000},
                new EmployeeModel(){ employeeName ="Berlin", basicPay= 25000},
                new EmployeeModel(){ employeeName ="Jimmy", basicPay= 30000},
                new EmployeeModel(){ employeeName ="Rupa", basicPay= 40000},
                new EmployeeModel(){ employeeName ="Jason", basicPay= 50000},
        };
            DateTime startDateTime = DateTime.Now;
            EmployeeRepo empRepoObj = new EmployeeRepo();
            empRepoObj.UpdateMultipleEmployeeSalary(empModelList);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (startDateTime - stopDateTime));
        }

        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:5000");
        }
        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void OnCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<EmployeeModel> dataResponse = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
            foreach (EmployeeModel item in dataResponse)
            {
                Console.WriteLine(item);
            }
        }
        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("employeeName", "Clark");
            jObjectbody.Add("companyId", 1);
            jObjectbody.Add("companyName", "Company1");
            jObjectbody.Add("departmentId", 101);
            jObjectbody.Add("departmentName", "Sales");
            jObjectbody.Add("gender", "F");
            jObjectbody.Add("phoneNumber", null);
            jObjectbody.Add("address", null);
            jObjectbody.Add("startDate", "12/12/2019");
            jObjectbody.Add("basicPay", 15000);
            jObjectbody.Add("deductions", 5000);
            jObjectbody.Add("taxablePay", 1000);
            jObjectbody.Add("tax", 1200);
            jObjectbody.Add("netPay", 45000);

            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);

        }
        [TestMethod]
        public void givenMultipleEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            JObject[] jObjectbody = new JObject[2];
            jObjectbody[0].Add("employeeName", "Clark");
            jObjectbody[0].Add("companyId", 1);
            jObjectbody[0].Add("companyName", "Company1");
            jObjectbody[0].Add("departmentId", 101);
            jObjectbody[0].Add("departmentName", "Sales");
            jObjectbody[0].Add("gender", "F");
            jObjectbody[0].Add("phoneNumber", null);
            jObjectbody[0].Add("address", null);
            jObjectbody[0].Add("startDate", "12/12/2019");
            jObjectbody[0].Add("basicPay", 15000);
            jObjectbody[0].Add("deductions", 5000);
            jObjectbody[0].Add("taxablePay", 1000);
            jObjectbody[0].Add("tax", 1200);
            jObjectbody[0].Add("netPay", 45000);

            jObjectbody[1].Add("employeeName", "Mahi");
            jObjectbody[1].Add("companyId", 1);
            jObjectbody[1].Add("companyName", "Company1");
            jObjectbody[1].Add("departmentId", 101);
            jObjectbody[1].Add("departmentName", "Sales");
            jObjectbody[1].Add("gender", "F");
            jObjectbody[1].Add("phoneNumber", null);
            jObjectbody[1].Add("address", null);
            jObjectbody[1].Add("startDate", "12/12/2019");
            jObjectbody[1].Add("basicPay", 15000);
            jObjectbody[1].Add("deductions", 5000);
            jObjectbody[1].Add("taxablePay", 1000);
            jObjectbody[1].Add("tax", 1200);
            jObjectbody[1].Add("netPay", 45000);

            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);

        }
    }
}
