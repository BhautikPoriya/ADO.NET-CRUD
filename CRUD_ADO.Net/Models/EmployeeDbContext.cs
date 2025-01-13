using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Runtime;

namespace CRUD_ADO.Net.Models
{
    public class EmployeeDbContext
    {
        string conenctionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public IList<Employee> getEmployeeList()
        {
            IList<Employee> employees = new List<Employee>();

            SqlConnection connection = new SqlConnection(conenctionString);
            string getEmployeeSp = "spGetAllEmployees";
            SqlCommand command = new SqlCommand(getEmployeeSp, connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Name = reader["Name"].ToString();
                employee.Gender = reader.GetValue(2).ToString();
                employee.Age = Convert.ToInt32(reader["Age"]);
                employee.City = reader["City"].ToString();
                employees.Add(employee);
            }

            connection.Close();

            return employees;
        }

        public bool InsertEmployee(Employee employee)
        {
            SqlConnection conenction = new SqlConnection(conenctionString);
            string insertEmployeeSP = "spInsertEmployee";
            SqlCommand command = new SqlCommand(insertEmployeeSP, conenction);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@gender", employee.Gender);
            command.Parameters.AddWithValue("@age", employee.Age);
            command.Parameters.AddWithValue("@city", employee.City);

            conenction.Open();
            int i = command.ExecuteNonQuery();
            conenction.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            SqlConnection conenction = new SqlConnection(conenctionString);
            string insertEmployeeSP = "spUpdateEmployee";
            SqlCommand command = new SqlCommand(insertEmployeeSP, conenction);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@gender", employee.Gender);
            command.Parameters.AddWithValue("@age", employee.Age);
            command.Parameters.AddWithValue("@city", employee.City);

            conenction.Open();
            int i = command.ExecuteNonQuery();
            conenction.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(conenctionString);
            string sp = "spDeleteEmployee";
            SqlCommand command = new SqlCommand(sp, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}