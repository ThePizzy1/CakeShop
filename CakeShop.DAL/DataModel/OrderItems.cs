using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CakeId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Changes { get; set; }

        public virtual Cake Cake { get; set; }
        public virtual Orders Order { get; set; }
    }
}
