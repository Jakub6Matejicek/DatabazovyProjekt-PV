using DatabasovyProjektPV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Tables
{
    internal class Order : IBaseClass
    {
        private int id;
        private DateTime date;
        private int customerId;
        private float totalPrice;

        public int ID { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Order(int id, DateTime date, int customerId, float totalPrice)
        {
            this.id = id;
            this.date = date;
            this.customerId = customerId;
            this.totalPrice = totalPrice;
        }

        public Order(DateTime date, int customerId, float totalPrice)
        {
            this.id = 0;
            this.date = date;
            this.customerId = customerId;
            this.totalPrice = totalPrice;
        }

        public override string? ToString()
        {
            return "Order( " + id + ", " + date + ", " + customerId + ", " + totalPrice + " )";
        }
    }
}
