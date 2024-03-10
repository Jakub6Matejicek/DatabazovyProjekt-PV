using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Menus
{
    internal class MenuItem
    {

        private string description { get; set; }
        private Dictionary<int, Action> menu { get; set; }

        public string ShowMenu()
        {
            string res = "\n" + description + " - Choose an action\n";
            for (int i = 1; i <= menu.Count; i++)
            {

                res += i + ") " + menu[i].description + "\n";

            }

            return res;
        }
    }
}
