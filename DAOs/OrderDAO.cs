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
    internal class OrderDAO : IRepozitory<Order>
    {
        public void Delete(Order element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Order WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Order", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        TotalPrice = Convert.ToSingle(reader["TotalPrice"])
                    };
                    yield return order;
                }
                reader.Close();
            }
        }

        public Order GetByID(int id)
        {
            Order order = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Order WHERE ID = @id", conn))
            {
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order = new Order
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        TotalPrice = Convert.ToSingle(reader["TotalPrice"])
                    };
                }
                reader.Close();
                return order;
            }
        }

        public void Save(Order element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Order (Date, CustomerId, TotalPrice) VALUES (@date, @customerId, @totalPrice); SELECT SCOPE_IDENTITY()", conn))
                {
                    command.Parameters.AddWithValue("@date", element.Date);
                    command.Parameters.AddWithValue("@customerId", element.CustomerId);
                    command.Parameters.AddWithValue("@totalPrice", element.TotalPrice);
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Order SET Date = @date, CustomerId = @customerId, TotalPrice = @totalPrice WHERE ID = @id", conn))
                {
                    command.Parameters.AddWithValue("@date", element.Date);
                    command.Parameters.AddWithValue("@customerId", element.CustomerId);
                    command.Parameters.AddWithValue("@totalPrice", element.TotalPrice);
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
