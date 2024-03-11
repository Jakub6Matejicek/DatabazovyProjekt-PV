using DatabasovyProjektPV.Core;
using DatabasovyProjektPV.Tables;
using DatabasovyProjektPV.Menus;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.start();
        }
    }
}