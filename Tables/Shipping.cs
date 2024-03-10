using DatabasovyProjektPV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Tables
{
    internal class Shipping : IBaseClass
    {
        private int id;
        private DateTime deliveryDate;
        private string address;
        private string status;
        private int orderId;

        public int ID { get => id; set => id = value; }
        public DateTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public string Address { get => address; set => address = value; }
        public string Status { get => status; set => status = value; }
        public int OrderId { get => orderId; set => orderId = value; }

        public Shipping(int id, DateTime deliveryDate, string address, string status, int orderId)
        {
            this.id = id;
            this.deliveryDate = deliveryDate;
            this.address = address;
            this.status = status;
            this.orderId = orderId;
        }

        public Shipping(DateTime deliveryDate, string address, string status, int orderId)
        {
            this.id = 0;
            this.deliveryDate = deliveryDate;
            this.address = address;
            this.status = status;
            this.orderId = orderId;
        }

        public override string? ToString()
        {
            return "Shipping( " + id + ", " + deliveryDate + ", " + address + ", " + status + ", " + orderId + " )";
        }
    }
}
