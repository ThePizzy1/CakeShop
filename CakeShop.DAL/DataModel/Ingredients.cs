using System;
using System.Collections.Generic;

namespace CakeShop.DAL.DataModel
{
    public partial class Ingredients
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Ingredient { get; set; }
        public string IngredientQuantity { get; set; }
        public string UnitOfMeasure { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
