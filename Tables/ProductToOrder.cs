using DatabasovyProjektPV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Tables
{
    internal class ProductToOrder : IBaseClass
    {
        private int productId;
        private int orderId;
        private int quantity;
        private int id;

        public int ID { get => id; set => id = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int OrderId { get => orderId; set => orderId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public ProductToOrder(int id, int productId, int orderId, int quantity)
        {
            this.id = id;
            this.productId = productId;
            this.orderId = orderId;
            this.quantity = quantity;
        }

        public ProductToOrder(int productId, int orderId, int quantity)
        {
            this.productId = productId;
            this.orderId = orderId;
            this.quantity = quantity;
        }

        public override string? ToString()
        {
            return "ProductToOrder( " + productId + ", " + orderId + ", " + quantity + " )";
        }
    }
}
