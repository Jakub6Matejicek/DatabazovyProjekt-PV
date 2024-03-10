using DatabasovyProjektPV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Tables
{
    internal class Product : IBaseClass
    {
        private int id;
        private string name;
        private int price;
        private bool isStocked;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public bool IsStocked { get => isStocked; set => isStocked = value; }

        public Product(int id, string name, int price, bool isStocked)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.isStocked = isStocked;
        }

        public Product(string name, int price, bool isStocked)
        {
            this.id = 0;
            this.name = name;
            this.price = price;
            this.isStocked = isStocked;
        }

        public override string? ToString()
        {
            return "Product( " + id + ", " + name + ", " + price + ", " + isStocked + " )";
        }
    }
}
