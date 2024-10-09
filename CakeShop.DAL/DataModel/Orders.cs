using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderDue { get; set; }
        public string OrderStatus { get; set; }
        public string PickupMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public int CakeId { get; set; }
        public int UserId { get; set; }

        public virtual Cake Cake { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
