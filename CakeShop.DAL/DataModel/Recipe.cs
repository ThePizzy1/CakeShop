using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        public int Id { get; set; }
        public int CakeId { get; set; }
        public string Recipe1 { get; set; }
        public string PreparationTime { get; set; }

        public virtual Cake Cake { get; set; }
        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
