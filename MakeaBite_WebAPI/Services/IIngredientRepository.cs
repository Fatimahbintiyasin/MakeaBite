using MakeaBite_Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeaBite_WebAPI.Services
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredients();

        Task<Ingredient> GetIngredientById(int id);

        Task<Ingredient> CreateIngredient(Ingredient ingredient);

        Task DeleteIngredient(int id);

        Task<Ingredient> UpdateIngredient(int id, Ingredient ingredient);

        Task<IEnumerable<Ingredient>> GetIngredientsForRecipe(int recipeId);

        Task<Ingredient> GetIngredientsForRecipeById(int recipeId, int ingredientId);

        Task AddIngredientsForRecipe(int recipeId, Ingredient ingredient);

        Task<bool> Save();
    }
}
