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
    internal class ProductMenu : MenuItem
    {

        ProductDAO dao;
        public ProductMenu()
        {
            dao = new ProductDAO();
            title = "Product";
            description = "Choose what to do with Product";
            menu = new Dictionary<int, (string d, Action a)>()
            {
                {1, ("Insert", Insert) },
                {2, ("Update", Update) },
                {3, ("Delete", Delete) },
                {4, ("Print", PrintAll<Product, ProductDAO>) },
                {5, ("Exit", () => { }) }
            };
        }

        void Insert()
        {
            string name;
            int price;
            bool isStocked;

            Console.WriteLine("Insert Name");
            name = Console.ReadLine();

            if (!TypeValidation<string>(name)) { Console.WriteLine("Invalid input"); return; }

            if (dao.GetAll().Select(x => x.Name).Contains(name))
            {
                Console.WriteLine("Product name exists"); return;
            }

            Console.WriteLine("Insert Price");
            if (!int.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine("Is Stocked? [true/false]");
            if (!bool.TryParse(Console.ReadLine(), out isStocked))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            dao.Save(new Product(name, price, isStocked));
        }

        void Update()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Product product = dao.GetByID(id);

            Console.WriteLine("[Press Enter to skip updating a field]");
            Console.WriteLine("Insert Name");
            string nameInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(nameInput))
            {
                if (!TypeValidation<string>(nameInput))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                if (dao.GetAll().Select(x => x.Name).Contains(nameInput))
                {
                    Console.WriteLine("Product name exists");
                    return;
                }

                product.Name = nameInput;
            }

            Console.WriteLine("Insert Price");
            string priceInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(priceInput))
            {
                if (!int.TryParse(priceInput, out int price))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                product.Price = price;
            }

            Console.WriteLine("Is Stocked? [true/false]");
            string isStockedInput = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(isStockedInput))
            {
                if (!bool.TryParse(isStockedInput, out bool isStocked))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                product.IsStocked = isStocked;
            }

            dao.Save(product);
        }

        void Delete()
        {
            Console.WriteLine("Insert ID");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Product product = dao.GetByID(id);
            dao.Delete(product);
        }

    }
}
