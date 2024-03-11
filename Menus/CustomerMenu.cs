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
    internal class CustomerMenu : MenuItem
    {
        CustomerDAO dao;

        public CustomerMenu()
        {
            dao = new CustomerDAO();
            title = "Customer";
            description = "Choose what to do with Customer";
            menu = new Dictionary<int, (string d, Action a)>()
        {
            {1, ("Insert", Insert) },
            {2, ("Update", Update) },
            {3, ("Delete", Delete) },
            {4, ("Print", () => PrintAll<Customer, CustomerDAO>()) },
            {5, ("Exit", () => { }) }
        };
        }

        void Insert()
        {
            string firstName, lastName, email;
            DateTime registrationDate = DateTime.Now;

            Console.WriteLine("Insert First Name");
            firstName = Console.ReadLine();

            if (!TypeValidation<string>(firstName)) { Console.WriteLine("Invalid input"); return; }

            Console.WriteLine("Insert Last Name");
            lastName = Console.ReadLine();

            if (!TypeValidation<string>(lastName)) { Console.WriteLine("Invalid input"); return; }

            Console.WriteLine("Insert Email");
            email = Console.ReadLine();

            if (!TypeValidation<string>(email)) { Console.WriteLine("Invalid input"); return; }

            dao.Save(new Customer(firstName, lastName, email, registrationDate));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Customer customer = dao.GetByID(id);

            Console.WriteLine("[Press Enter to skip updating a field]");
            Console.WriteLine("Insert First Name");
            string firstNameInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(firstNameInput))
            {
                if (!TypeValidation<string>(firstNameInput))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                customer.FirstName = firstNameInput;
            }

            Console.WriteLine("Insert Last Name");
            string lastNameInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(lastNameInput))
            {
                if (!TypeValidation<string>(lastNameInput))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                customer.LastName = lastNameInput;
            }

            Console.WriteLine("Insert Email");
            string emailInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(emailInput))
            {
                if (!TypeValidation<string>(emailInput))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                customer.Email = emailInput;
            }

            dao.Save(customer);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Customer customer = dao.GetByID(id);
            dao.Delete(customer);
        }
    }

}

