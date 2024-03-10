using DatabasovyProjektPV.Core;
using DatabasovyProjektPV.Tables;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.DAOs
{
    internal class ProductDAO : IRepozitory<Product>
    {
        public void Delete(Product element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToInt32(reader["Price"]),
                        IsStocked = Convert.ToBoolean(reader["IsStocked"])
                    };
                    yield return product;
                }
                reader.Close();
            }
        }

        public Product GetByID(int id)
        {
            Product product = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Price = Convert.ToInt32(reader["Price"]),
                        IsStocked = Convert.ToBoolean(reader["IsStocked"])
                    };
                }
                reader.Close();
                return product;
            }
        }

        public void Save(Product element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Products (Name, Price, IsStocked) VALUES (@name, @price, @isStocked); SELECT SCOPE_IDENTITY()", conn))
                {
                    command.Parameters.AddWithValue("@name", element.Name);
                    command.Parameters.AddWithValue("@price", element.Price);
                    command.Parameters.AddWithValue("@isStocked", element.IsStocked);
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Products SET Name = @name, Price = @price, IsStocked = @isStocked WHERE ID = @id", conn))
                {
                    command.Parameters.AddWithValue("@name", element.Name);
                    command.Parameters.AddWithValue("@price", element.Price);
                    command.Parameters.AddWithValue("@isStocked", element.IsStocked);
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
