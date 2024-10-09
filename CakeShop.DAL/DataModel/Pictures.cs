using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class Pictures
    {
        public int Id { get; set; }
        public int CakeId { get; set; }
        public byte[] Picture { get; set; }

        public virtual Cake Cake { get; set; }
    }
}
