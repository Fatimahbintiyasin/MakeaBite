using MakeaBite_Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MakeaBite_WebAPI.Services
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipeById(int id);

        Task<Recipe> CreateRecipe(Recipe recipe);

        Task DeleteRecipe(int id);

        Task<Recipe> UpdateRecipe(int id, Recipe recipe);

        Task<bool> SaveAsync();
    }
}
