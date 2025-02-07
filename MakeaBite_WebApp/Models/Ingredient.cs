using System.ComponentModel;

namespace MakeaBite_WebApp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [DisplayName("Ingredient Name")]
        public string IngredientName { get; set; }

        [DisplayName("Ingredient Amount")]
        public string IngredientAmount { get; set; }
    }
}
