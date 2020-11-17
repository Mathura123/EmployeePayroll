namespace EmployeePayroll
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

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
                            GetDetailsFromSqlDataReader(dr, employeeModel);
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
                            GetDetailsFromSqlDataReader(dr, employeeModel);
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
                            GetDetailsFromSqlDataReader(dr, employeeModel);
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
            int id = default(int);
            SqlTransaction objTrans = null;
            try
            {
                empModel.companyId = GetCompanyId(empModel.companyName);
                if (empModel.employeeName.Equals(default(string)))
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.NO_EMP_NAME, "No employee name given");
            }
            catch (EmployeePayrollException e)
            {
                CustomPrint.PrintInMagenta(e.Message);
                return false;
            }
            empModel.departmentId = GetDeptId(empModel.departmentName).ToArray();
            if (empModel.departmentId.Length > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    objTrans = connection.BeginTransaction();
                    if (!SearchDublicatesInCompany(empModel.employeeName, empModel.companyName))
                        AddEmployeeIfNoCompanyDublicate(empModel, connection, objTrans, ref id);
                    else
                        GetEmpIdIfCompanyDublicate(empModel, connection, objTrans, ref id);
                    try
                    {
                        int row2 = 0;
                        foreach (int deptId in GetDistinctDeptId(empModel.employeeName, empModel.companyName, empModel.departmentId))
                        {
                            SqlCommand command3 = new SqlCommand($"insert into employee_department values " +
                               $"({id},{deptId});", connection, objTrans);
                            int row3 = command3.ExecuteNonQuery();
                            row2 += row3;
                            if (row3 == 0)
                                throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.WRONG_EMP_DETAILS, "Incorrect Employee Details");
                        }
                        objTrans.Commit();
                        CustomPrint.PrintInRed($"{row2} rows inserted");
                    }
                    catch (Exception e)
                    {
                        CustomPrint.PrintInMagenta(e.Message);
                        objTrans.Rollback();
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return true;
            }
            return false;
        }
        public bool DeleteEmployee(string empName, string companyName, string[] deptNames)
        {
            int row = 0;
            foreach (string deptName in deptNames)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"delete from employee_department " +
                            $"where employee_department.dept_id in " +
                            $"(select d.dept_id from department d where d.dept_name = '{deptName}') and " +
                            $"employee_department.employee_id in " +
                            $"(select e.employee_id from employee e where e.name = '{empName}' )", connection);
                        row += command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        CustomPrint.PrintInMagenta(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            if (row > 0)
            {
                CustomPrint.PrintInRed($"{row} rows affected");
                return true;
            }
            CustomPrint.PrintInMagenta("Employee Not Found");
            return false;
        }

        /// <summary>Gets the dept identifier.</summary>
        /// <param name="deptName">Name of the dept.</param>
        /// <returns>DeptId</returns>
        /// <exception cref="EmployeePayrollException">Dept Not Found</exception>
        private List<int> GetDeptId(string[] deptNames)
        {
            List<int> deptIds = new List<int>();
            foreach (string deptName in deptNames)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command1 = new SqlCommand($"select dept_id from department where dept_name = '{deptName}'", connection);
                        SqlDataReader dr = command1.ExecuteReader();
                        int deptId = 0;
                        while (dr.Read())
                        {
                            deptId = dr.GetInt32(0);
                        }
                        if (deptId == 0)
                            throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.DEPT_NOT_FOUND, $"Dept {deptName} Not Found");
                        deptIds.Add(deptId);
                    }
                    catch (Exception e)
                    {
                        CustomPrint.PrintInMagenta(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return deptIds;
        }
        /// <summary>Gets the company identifier.</summary>
        /// <param name="companyName">Name of the company.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="EmployeePayrollException">Company Not Found</exception>
        private int GetCompanyId(string companyName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand($"select company_id from company where company_name = '{companyName}'", connection);
                    SqlDataReader dr = command1.ExecuteReader();
                    int companyId = 0;
                    while (dr.Read())
                    {
                        companyId = dr.GetInt32(0);
                    }
                    if (companyId == 0)
                        throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.COMPANY_NOT_FOUND, $"Company {companyName} Not Found");
                    return companyId;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        /// <summary>Searches the dublicates.</summary>
        /// <param name="empName">Name of the emp.</param>
        /// <param name="empCompanyName">Name of the emp company.</param>
        /// <param name="deptId">The dept identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="EmployeePayrollException">Employee is already added</exception>
        private int[] GetDistinctDeptId(string empName, string empCompanyName, int[] deptIds)
        {
            List<int> distinctdeptIds = new List<int>();
            foreach (int deptId in deptIds)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"select * from company c " +
                            $"inner join employee e on c.company_id = e.company_id " +
                            $"inner join employee_department ed on ed.employee_id = e.employee_id " +
                            $"inner join department d on d.dept_id = ed.dept_id " +
                            $"inner join payroll p on p.employee_id = e.employee_id " +
                            $"where e.name = '{empName}' and c.company_name = '{empCompanyName}' and d.dept_id = {deptId}", connection);
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                            throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.EMP_ALREADY_ADDED, $"Employee is already added in dept with id {deptId}");
                        distinctdeptIds.Add(deptId);
                    }
                    catch (Exception e)
                    {
                        CustomPrint.PrintInMagenta(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return distinctdeptIds.ToArray();
        }
        private bool SearchDublicatesInCompany(string empName, string empCompanyName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"select * from company c " +
                        $"inner join employee e on c.company_id = e.company_id " +
                        $"inner join employee_department ed on ed.employee_id = e.employee_id " +
                        $"inner join department d on d.dept_id = ed.dept_id " +
                        $"inner join payroll p on p.employee_id = e.employee_id " +
                        $"where e.name = '{empName}' and c.company_name = '{empCompanyName}'", connection);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                        throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.EMP_ALREADY_ADDED, $"Employee is already added in company {empCompanyName}");
                    return false;
                }
                catch (Exception e)
                {
                    CustomPrint.PrintInMagenta(e.Message);
                    return true;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void GetDetailsFromSqlDataReader(SqlDataReader dr, EmployeeModel employeeModel)
        {
            employeeModel.employeeID = dr.GetInt32(0);
            employeeModel.employeeName = dr.GetString(1);
            employeeModel.companyId = dr.GetInt32(2);
            employeeModel.companyName = dr.GetString(3);
            employeeModel.departmentId = new int[] { dr.GetInt32(4) };
            employeeModel.departmentName = new string[] { dr.GetString(5) };
            employeeModel.gender = dr.IsDBNull(6) ? " " : dr.GetString(6);
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
        private void AddEmployeeIfNoCompanyDublicate(EmployeeModel empModel,SqlConnection connection, SqlTransaction objTrans, ref int id)
        {
            SqlCommand command1 = new SqlCommand($"insert into employee values " +
                            $"({empModel.companyId},'{empModel.employeeName}','{empModel.gender}','{empModel.phoneNumber}','{empModel.address}'); " +
                                                   "Select @@identity", connection, objTrans);
            id = Convert.ToInt32(command1.ExecuteScalar());
            SqlCommand command2 = new SqlCommand($"insert into payroll values " +
                $"({id},'{empModel.startDate.ToString("yyyy-MM-dd")}',{empModel.basicPay});", connection, objTrans);
            var row = command2.ExecuteNonQuery();
        }
        private void GetEmpIdIfCompanyDublicate(EmployeeModel empModel, SqlConnection connection, SqlTransaction objTrans, ref int id)
        {
            SqlCommand command = new SqlCommand($"select employee_id from employee " +
                            $"where name = '{empModel.employeeName}' and " +
                            $"employee.company_id in (select company_id from company where company_name = '{empModel.companyName}')", connection, objTrans);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            dr.Close();
        }
    }
}
