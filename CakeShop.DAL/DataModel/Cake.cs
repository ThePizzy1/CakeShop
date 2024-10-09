using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class Cake
    {
        public Cake()
        {
            OrderItems = new HashSet<OrderItems>();
            Orders = new HashSet<Orders>();
            Pictures = new HashSet<Pictures>();
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Pictures> Pictures { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
