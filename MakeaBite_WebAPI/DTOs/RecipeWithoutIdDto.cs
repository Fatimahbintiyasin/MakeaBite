namespace MakeaBite_WebAPI.DTOs
{
    public class RecipeWithoutIdDto
    {
        public string RecipeName { get; set; } 
        public string RecipeType { get; set; } 
        public string? Description { get; set; }
        public string? ImageIrl { get; set; }
        public string AuthorId { get; set; } 

        public virtual ICollection<IngredientDto> Ingredients { get; set; }
    }
}
