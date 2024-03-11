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
    internal class ShippingMenu : MenuItem
    {
        ShippingDAO dao;

        public ShippingMenu()
        {
            dao = new ShippingDAO();
            title = "Shipping";
            description = "Choose what to do with Shipping";
            menu = new Dictionary<int, (string d, Action a)>()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print", () => PrintAll<Shipping, ShippingDAO>()) },
                {5, ("Exit", () => { }) }
            };
        }

        void Insert()
        {
            DateTime deliveryDate;
            string address;
            string status;
            int orderId;

            Console.WriteLine("Insert Delivery Date (yyyy-MM-dd HH:mm:ss)");
            if (!DateTime.TryParse(Console.ReadLine(), out deliveryDate))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Insert Address");
            address = Console.ReadLine();

            Console.WriteLine("Insert Status");
            status = Console.ReadLine();

            Console.WriteLine("Insert Order ID");
            if (!int.TryParse(Console.ReadLine(), out orderId))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new Shipping(deliveryDate, address, status, orderId));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Shipping shipping = dao.GetByID(id);

            Console.WriteLine("[Press Enter to skip updating a field]");
            Console.WriteLine("Insert Delivery Date (yyyy-MM-dd HH:mm:ss)");
            string deliveryDateInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(deliveryDateInput))
            {
                if (!DateTime.TryParse(deliveryDateInput, out DateTime deliveryDate))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                shipping.DeliveryDate = deliveryDate;
            }

            Console.WriteLine("Insert Address");
            string addressInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(addressInput))
            {
                shipping.Address = addressInput;
            }

            Console.WriteLine("Insert Status");
            string statusInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(statusInput))
            {
                shipping.Status = statusInput;
            }

            Console.WriteLine("Insert Order ID");
            string orderIdInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(orderIdInput))
            {
                if (!int.TryParse(orderIdInput, out int orderId))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                shipping.OrderId = orderId;
            }

            dao.Save(shipping);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Shipping shipping = dao.GetByID(id);
            dao.Delete(shipping);
        }
    }

}
