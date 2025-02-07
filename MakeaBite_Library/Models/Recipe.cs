using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeaBite_Library.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeType { get; set; }
        public string Description { get; set; }
        public string ImageIrl { get; set; }
        public string AuthorId { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
