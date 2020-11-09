namespace EmployeePayroll
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection.Metadata.Ecma335;

    public class EmployeeRepo
    {
        /// <summary>The connection string</summary>
        public static string connectionString = @"Data Source=DESKTOP-8UMNEFU\MSSQLSERVER01;Initial Catalog=payroll_service;Integrated Security=True";
        //SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>Checks the connection.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool CheckConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    CustomPrint.PrintInRed("Connection is opened");
                    CustomPrint.PrintInRed("Connection good");
                    connection.Close();
                    CustomPrint.PrintInRed("Connection is closed");
                    return true;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets all employee.</summary>
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SelectAllRowsFromEmployeePayroll";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"All employees data :");
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
                            employeeModel.gender = dr.IsDBNull(6) ? ' ' : Convert.ToChar(dr.GetString(6));
                            employeeModel.phoneNumber = dr.IsDBNull(7) ? " " : dr.GetString(7);
                            employeeModel.address = dr.IsDBNull(8) ? " " : dr.GetString(8);
                            employeeModel.startDate = dr.GetDateTime(9);
                            employeeModel.basicPay = Math.Round(dr.GetDecimal(10),2);
                            employeeModel.deductions = Math.Round(dr.GetDecimal(11), 2);
                            employeeModel.taxablePay = Math.Round(dr.GetDecimal(12), 2);
                            employeeModel.tax = Math.Round(dr.GetDecimal(10), 2);
                            employeeModel.netPay = Math.Round(dr.GetDecimal(10), 2);
                            Console.WriteLine(employeeModel);
                        }
                        CustomPrint.PrintDashLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        CustomPrint.PrintInMagenta("No data found");
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
            }
        }
        /// <summary>Updates the employee salary.</summary>
        /// <param name="model">The empModel</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool UpdateEmployeeSalary(EmployeeModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateSalaryByName", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.employeeName);
                    command.Parameters.AddWithValue("@BasicPay", model.basicPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    CustomPrint.PrintInRed($"{result} rows affected");
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets employee by name.</summary>
        /// <param name="empName">Name of the emp.</param>
        /// <returns>true if emp model is returned.false if no data or connection failed</returns>
        public bool GetEmpByName(string empName)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetEmpByName", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", empName);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"Data for employee with name : {empName}");
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
                            employeeModel.gender = dr.IsDBNull(6) ? ' ' : Convert.ToChar(dr.GetString(6));
                            employeeModel.phoneNumber = dr.IsDBNull(7) ? " " : dr.GetString(7);
                            employeeModel.address = dr.IsDBNull(8) ? " " : dr.GetString(8);
                            employeeModel.startDate = dr.GetDateTime(9);
                            employeeModel.basicPay = Math.Round(dr.GetDecimal(10), 2);
                            employeeModel.deductions = Math.Round(dr.GetDecimal(11), 2);
                            employeeModel.taxablePay = Math.Round(dr.GetDecimal(12), 2);
                            employeeModel.tax = Math.Round(dr.GetDecimal(10), 2);
                            employeeModel.netPay = Math.Round(dr.GetDecimal(10), 2);
                            Console.WriteLine(employeeModel);
                        }
                        CustomPrint.PrintDashLine();
                        Console.WriteLine();
                        return true;
                    }
                    CustomPrint.PrintInMagenta("No data found");
                    connection.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets the emp in given date range.</summary>
        /// <param name="initialDate">The initial date.</param>
        /// <param name="lastDate">The last date.</param>
        /// <returns>true if emp model is returned.false if no data or connection failed</returns>
        public bool GetEmpInDateRange(DateTime initialDate, DateTime lastDate)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetEmpInDateRange", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@initialDate", initialDate);
                    command.Parameters.AddWithValue("@lastDate", lastDate);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"Data for employees who started within {initialDate.ToShortDateString()} and {lastDate.ToShortDateString()} : ");
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
                            employeeModel.gender = dr.IsDBNull(6) ? ' ' : Convert.ToChar(dr.GetString(6));
                            employeeModel.phoneNumber = dr.IsDBNull(7) ? " " : dr.GetString(7);
                            employeeModel.address = dr.IsDBNull(8) ? " " : dr.GetString(8);
                            employeeModel.startDate = dr.GetDateTime(9);
                            employeeModel.basicPay = Math.Round(dr.GetDecimal(10), 2);
                            employeeModel.deductions = Math.Round(dr.GetDecimal(11), 2);
                            employeeModel.taxablePay = Math.Round(dr.GetDecimal(12), 2);
                            employeeModel.tax = Math.Round(dr.GetDecimal(10), 2);
                            employeeModel.netPay = Math.Round(dr.GetDecimal(10), 2);
                            Console.WriteLine(employeeModel);
                        }
                        CustomPrint.PrintDashLine();
                        Console.WriteLine();
                        return true;
                    }
                    CustomPrint.PrintInMagenta("No data found");
                    connection.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Gets the aggregate values of employees basic salary by gender.</summary>
        /// <returns>true if dr is returned and has rows.false if no data or connection failed</returns>
        public bool GetAggValuesOfEmpByGender()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("GetAggValuesByGender", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        CustomPrint.PrintInRed($"Aggregate Values of basic salary for employees are : ");
                        CustomPrint.PrintDashLine();
                        Console.WriteLine(CustomPrint.PrintRow("Gender", "Sum", "Average", "Min", "Max", "Count"));
                        CustomPrint.PrintDashLine();
                        while (dr.Read())
                        {
                            string gender = dr.GetString(0);
                            string sum = dr.GetDecimal(1).ToString();
                            string average = dr.GetDecimal(2).ToString();
                            string min = dr.GetDecimal(3).ToString();
                            string max = dr.GetDecimal(4).ToString();
                            string count = dr.GetInt32(5).ToString();
                            Console.WriteLine(CustomPrint.PrintRow(gender, sum, average, min, max, count));
                        }
                        CustomPrint.PrintDashLine();
                        Console.WriteLine();
                        return true;
                    }
                    CustomPrint.PrintInMagenta("No data found");
                    connection.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
        /// <summary>Adds the employee.</summary>
        /// <param name="empModel">The emp model.</param>
        /// <returns>true if dr is returned and has rows.false if no data or connection failed</returns>
        public bool AddEmployee(EmployeeModel empModel)
        {
            try
            {
                if (empModel.companyId.Equals(default(int)))
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.NO_COMPANY_ID, "No company id given");
                if (empModel.employeeName.Equals(default(string)))
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.NO_EMP_NAME, "No employee name given");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("InsertEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@companyId", empModel.companyId);
                    command.Parameters.AddWithValue("@name", empModel.employeeName);
                    command.Parameters.AddWithValue("@gender", String.IsNullOrEmpty(empModel.gender.ToString()) ? Convert.DBNull : empModel.gender);
                    command.Parameters.AddWithValue("@phoneNo", empModel.phoneNumber ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@address", empModel.address ?? Convert.DBNull);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    CustomPrint.PrintInRed($"{result} rows affected");
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
        }
    }
}
