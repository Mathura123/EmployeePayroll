using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-8UMNEFU\MSSQLSERVER01;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool CheckConnection()
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    Console.WriteLine("Connection is opened");
                    Console.WriteLine("Connection good");
                    this.connection.Close();
                    Console.WriteLine("Connection is closed");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SelectAllRowsFromEmployeePayroll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("Emp ID", "Emp Name", "Company ID", "Company Name", "Dept ID", "Dept Name", "Gender", "Phone No", "Address", "Start Date", "Basic Pay", "Deductions", "Taxable Pay", "Tax", "Net Pay"));
                        CustomPrint.PrintDashLine();
                        while (dr.Read())
                        {
                            employeeModel.employeeID = dr.GetInt32(0);
                            employeeModel.employeeName = dr.GetString(1);
                            employeeModel.companyId = dr.GetInt32(2);
                            employeeModel.companyName = dr.GetString(3);
                            employeeModel.departmentId = dr.GetInt32(4);
                            employeeModel.departmentName = dr.GetString(5);
                            employeeModel.gender = Convert.ToChar(dr.GetString(6));
                            employeeModel.phoneNumber = dr.GetString(7);
                            employeeModel.address = dr.GetString(8);
                            employeeModel.startDate = dr.GetDateTime(9);
                            employeeModel.basicPay = dr.GetDecimal(10);
                            employeeModel.deductions = dr.GetDecimal(11);
                            employeeModel.taxablePay = dr.GetDecimal(12);
                            employeeModel.tax = dr.GetDecimal(13);
                            employeeModel.netPay = dr.GetDecimal(14);
                            Console.WriteLine(employeeModel);
                        }
                        CustomPrint.PrintDashLine();
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
