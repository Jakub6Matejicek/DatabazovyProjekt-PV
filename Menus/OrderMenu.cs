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
    internal class OrderMenu : MenuItem
    {
        OrderDAO dao;

        public OrderMenu()
        {
            dao = new OrderDAO();
            title = "Order";
            description = "Choose what to do with Order";
            menu = new Dictionary<int, (string d, Action a)>()
        {
            {1, ("Insert", Insert) },
            {2, ("Update", Update) },
            {3, ("Delete", Delete) },
            {4, ("Print", () => PrintAll<Order, OrderDAO>()) },
            {5, ("Exit", () => { }) }
        };
        }

        void Insert()
        {
            int customerId;
            float totalPrice;
            DateTime orderDate = DateTime.Now;

            Console.WriteLine("Insert Customer ID");
            if (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Total Price");
            if (!float.TryParse(Console.ReadLine(), out totalPrice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new Order(orderDate, customerId, totalPrice));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Order order = dao.GetByID(id);

            Console.WriteLine("[Press Enter to skip updating a field]");
            Console.WriteLine("Insert Customer ID");
            string customerIdInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(customerIdInput))
            {
                if (!int.TryParse(customerIdInput, out int customerId))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                order.CustomerID = customerId;
            }

            Console.WriteLine("Insert Total Price");
            string totalPriceInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(totalPriceInput))
            {
                if (!float.TryParse(totalPriceInput, out float totalPrice))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                order.TotalPrice = totalPrice;
            }

            dao.Save(order);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Order order = dao.GetByID(id);
            dao.Delete(order);
        }
    }

}
