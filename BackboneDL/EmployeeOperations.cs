using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BackboneDL
{
    public class EmployeeOperations
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string connectionString = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        KnownAs = reader.GetString(2),
                        Surname = reader.GetString(3),
                        ContactNumber = reader.GetString(4),
                        Position = reader.GetString(5)
                    });
                }
            }

            return employees;
        }

        public Employee GetEmployee()
        {
            Employee employee = new Employee();
            string connectionString = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.KnownAs = reader.GetString(2);
                    employee.Surname = reader.GetString(3);
                    employee.ContactNumber = reader.GetString(4);
                    employee.Position = reader.GetString(5);
                    break;
                }
            }

            return employee;
        }

        public int DeleteEmployee(int id)
        {
            int results = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                results = command.ExecuteNonQuery();
            }
            return results;
        }

        public int UpdatEmployee(Employee employee)
        {
            int results = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@KnownAs", employee.KnownAs);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                results = command.ExecuteNonQuery();
            }
            return results;
        }

        public Employee AddNewEmployee(Employee employee)
        {
            Employee results = new Employee(); ;
            string connectionString = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                
                SqlCommand command = new SqlCommand("AddNewEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@KnownAs", employee.KnownAs);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    results.Id = reader.GetInt32(0);
                    results.Name = reader.GetString(1);
                    results.KnownAs = reader.GetString(2);
                    results.Surname = reader.GetString(3);
                    results.ContactNumber = reader.GetString(4);
                    results.Position = reader.GetString(5);
                }
                    }
            return results;
        }
    }
}
