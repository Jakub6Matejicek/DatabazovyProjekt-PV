using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasovyProjektPV.Core;
using DatabasovyProjektPV.Tables;
using DatabasovyProjektPV.DAOs;

namespace DatabasovyProjektPV.Menus
{
    internal class ProductToOrderMenu : MenuItem
    {
        ProductToOrderDAO dao;

        public ProductToOrderMenu()
        {
            dao = new ProductToOrderDAO();
            title = "Product To Order";
            description = "Choose what to do with Product To Order";
            menu = new Dictionary<int, (string d, Action a)>()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print", () => PrintAll<ProductToOrder, ProductToOrderDAO>()) },
                {5, ("Exit", () => { }) }
            };
        }

        void Insert()
        {
            int productId;
            int orderId;
            int quantity;

            Console.WriteLine("Insert Product ID");
            if (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Order ID");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Quantity");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new ProductToOrder(productId, orderId, quantity));
        }

        void Update()
        {
            Console.WriteLine("Insert Product ID");

            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Order ID");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            ProductToOrder productToOrder = dao.GetByID(productId, orderId);

            if (productToOrder == null)
            {
                Console.WriteLine("ProductToOrder not found");
                return;
            }

            Console.WriteLine("[Press Enter to skip updating a field]");
            Console.WriteLine("Insert Quantity");
            string quantityInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(quantityInput))
            {
                if (!int.TryParse(quantityInput, out int quantity))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                productToOrder.Quantity = quantity;
            }

            dao.Save(productToOrder);
        }

        void Delete()
        {
            Console.WriteLine("Insert Product ID");

            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Order ID");

            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            ProductToOrder productToOrder = dao.GetByID(productId, orderId);

            if (productToOrder == null)
            {
                Console.WriteLine("ProductToOrder not found");
                return;
            }

            dao.Delete(productToOrder);
        }
    }
}
