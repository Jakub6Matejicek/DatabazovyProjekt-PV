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
    internal class ProductToOrderDAO : IRepozitory<ProductToOrder>
    {
        public void Delete(ProductToOrder element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM ProductToOrder WHERE ProductId = @productId AND OrderId = @orderId", conn))
            {
                command.Parameters.AddWithValue("@productId", element.ProductId);
                command.Parameters.AddWithValue("@orderId", element.OrderId);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductToOrder> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM ProductToOrder", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductToOrder productToOrder = new ProductToOrder
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };
                    yield return productToOrder;
                }
                reader.Close();
            }
        }

        public ProductToOrder GetByID(int productId, int orderId)
        {
            ProductToOrder productToOrder = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM ProductToOrder WHERE ProductId = @productId AND OrderId = @orderId", conn))
            {
                command.Parameters.AddWithValue("@productId", productId);
                command.Parameters.AddWithValue("@orderId", orderId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productToOrder = new ProductToOrder
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };
                }
                reader.Close();
                return productToOrder;
            }
        }

        public void Save(ProductToOrder element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            SqlCommand command = null;

            if (GetByID(element.ProductId, element.OrderId) == null)
            {
                using (command = new SqlCommand("INSERT INTO ProductToOrder (ProductId, OrderId, Quantity) VALUES (@productId, @orderId, @quantity)", conn))
                {
                    command.Parameters.AddWithValue("@productId", element.ProductId);
                    command.Parameters.AddWithValue("@orderId", element.OrderId);
                    command.Parameters.AddWithValue("@quantity", element.Quantity);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE ProductToOrder SET Quantity = @quantity WHERE ProductId = @productId AND OrderId = @orderId", conn))
                {
                    command.Parameters.AddWithValue("@quantity", element.Quantity);
                    command.Parameters.AddWithValue("@productId", element.ProductId);
                    command.Parameters.AddWithValue("@orderId", element.OrderId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
