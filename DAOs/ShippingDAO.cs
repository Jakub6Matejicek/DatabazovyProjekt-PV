using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabasovyProjektPV.Core;
using DatabasovyProjektPV.Tables;

namespace DatabasovyProjektPV.DAOs
{
    internal class ShippingDAO : IRepozitory<Shipping>
    {
        public void Delete(Shipping element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Shipping WHERE id = @id", conn))
            {
                command.Parameters.Add("@id", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Shipping> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Shipping", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Shipping shipping = new Shipping
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                        Address = Convert.ToString(reader["Address"]),
                        Status = Convert.ToString(reader["Status"]),
                        OrderId = Convert.ToInt32(reader["OrderId"])
                    };
                    yield return shipping;
                }
                reader.Close();
            }
        }

        public Shipping GetByID(int id)
        {
            Shipping shipping = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Shipping WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shipping = new Shipping
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                        Address = Convert.ToString(reader["Address"]),
                        Status = Convert.ToString(reader["Status"]),
                        OrderId = Convert.ToInt32(reader["OrderId"])
                    };
                }
                reader.Close();
                return shipping;
            }
        }

        public void Save(Shipping element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            if (element.ID < 1)
            {
                using (command = new SqlCommand("INSERT INTO Shipping (DeliveryDate, Address, Status, OrderId) VALUES (@deliveryDate, @address, @status, @orderId); SELECT SCOPE_IDENTITY()", conn))
                {
                    command.Parameters.AddWithValue("@deliveryDate", element.DeliveryDate);
                    command.Parameters.AddWithValue("@address", element.Address);
                    command.Parameters.AddWithValue("@status", element.Status);
                    command.Parameters.AddWithValue("@orderId", element.OrderId);
                    element.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Shipping SET DeliveryDate = @deliveryDate, Address = @address, Status = @status, OrderId = @orderId WHERE ID = @id", conn))
                {
                    command.Parameters.AddWithValue("@deliveryDate", element.DeliveryDate);
                    command.Parameters.AddWithValue("@address", element.Address);
                    command.Parameters.AddWithValue("@status", element.Status);
                    command.Parameters.AddWithValue("@orderId", element.OrderId);
                    command.Parameters.AddWithValue("@id", element.ID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
