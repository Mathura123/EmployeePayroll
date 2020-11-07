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
            catch(Exception e)
            {
               Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
