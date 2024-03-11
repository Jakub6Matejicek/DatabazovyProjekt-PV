using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Menus
{
    internal class Menu
    {

        private bool isOn = true;
        private string description = "Select Table you want to operate with";
        private Dictionary<int, MenuItem> menu = new Dictionary<int, MenuItem>()
        {
            {1, new ProductMenu()},
            {2, new CustomerMenu()},
            {3, new OrderMenu()},
            {4, new ShippingMenu()},
            {5, new ProductToOrderMenu()},

        };


        
        public void ShowMenu()
        {
            Console.WriteLine("\n" + description + "\n");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine("\n" + i + ") " + menu[i].title);
            }
        }

        public void start()
        {
            while (isOn)
            {
                ShowMenu();

                if (int.TryParse(Console.ReadLine(), out int i) && i <= menu.Count)
                {
                    menu[i].start();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


            }
        }


    }
}
