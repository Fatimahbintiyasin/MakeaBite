using System.ComponentModel;
using System.Collections.Generic;

namespace MakeaBite_WebApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [DisplayName("Recipe name")]
        public string RecipeName { get; set; }

        [DisplayName("Recipe type")]
        public string RecipeType { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Image")]
        public string ImageIrl { get; set; }

        [DisplayName("Author")]
        public string AuthorId { get; set; }

        [DisplayName("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }
    }
}
