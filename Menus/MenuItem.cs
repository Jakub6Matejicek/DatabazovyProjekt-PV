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
    internal class MenuItem
    {

        public virtual string title { get; set; }
        public virtual  string description { get; set; }
        public virtual Dictionary<int, (string d, Action a)> menu { get; set; }


        public string ShowMenu()
        {
            string res = "\n" + description + "\n";
            for (int i = 1; i <= menu.Count; i++)
            {
                res += i + ") " + menu[i].d + "\n";
            }

            return res;
        }

        public void start()
        {
            Console.WriteLine(ShowMenu());

            if(int.TryParse(Console.ReadLine(), out int i) && i <= menu.Count)
            {
                menu[i].a();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public static bool IDValidation<DAO, Table>(int id) where Table : IBaseClass where DAO : IRepozitory<Table>, new()
        {
            DAO dao = new();
            if (dao.GetByID(id) == null)
            {
                return false;
            }

            return true;
        }

        public static void PrintAll<Table, DAO>() where Table : IBaseClass where DAO : IRepozitory<Table>, new()
        {
            DAO dao = new();
            foreach (Table dm in dao.GetAll())
            {
                Console.WriteLine(dm);
            }
        }

        public static bool TypeValidation<T>(T toValidate)
        {
            return toValidate switch
            {
                string s => s.Length > 0,
                int i => i > 0,
                float f => f > 0,

            };
        }

    }
}
