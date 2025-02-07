using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeaBite_Library.Models
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string IngredientAmount { get; set; }
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
