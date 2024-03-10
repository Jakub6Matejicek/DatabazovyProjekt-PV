using DatabasovyProjektPV.Core;
using DatabasovyProjektPV.Tables;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.DAOs
{
    internal class CustomerDAO : IRepozitory<Customer>
    {
        public void Delete(Customer element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Customers WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        Email = Convert.ToString(reader["Email"]),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                    };
                    yield return customer;
                }
                reader.Close();
            }
        }

        public Customer GetByID(int id)
        {
            Customer customer = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        Email = Convert.ToString(reader["Email"]),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                    };
                }
                reader.Close();
                return customer;
            }
        }

        public void Save(Customer element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Customers (FirstName, LastName, Email, RegistrationDate) VALUES (@firstName, @lastName, @email, @registrationDate); SELECT SCOPE_IDENTITY()", conn))
                {
                    command.Parameters.AddWithValue("@firstName", element.FirstName);
                    command.Parameters.AddWithValue("@lastName", element.LastName);
                    command.Parameters.AddWithValue("@email", element.Email);
                    command.Parameters.AddWithValue("@registrationDate", element.RegistrationDate);
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Customers SET FirstName = @firstName, LastName = @lastName, Email = @email, RegistrationDate = @registrationDate WHERE ID = @id", conn))
                {
                    command.Parameters.AddWithValue("@firstName", element.FirstName);
                    command.Parameters.AddWithValue("@lastName", element.LastName);
                    command.Parameters.AddWithValue("@email", element.Email);
                    command.Parameters.AddWithValue("@registrationDate", element.RegistrationDate);
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
