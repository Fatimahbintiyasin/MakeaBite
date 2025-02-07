using Microsoft.EntityFrameworkCore;
using MakeaBite_Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeaBite_WebAPI.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private MakeaBiteContext _context;

        public RecipeRepository(MakeaBiteContext context)
        {
            _context = context;
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            var res = await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteRecipe(int id)
        {
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            foreach (var ing in _context.Ingredients)
            {
                if (ing.Recipe == recipe)
                {
                    _context.Ingredients.Remove(ing);
                }
            }
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _context.Recipes.Include(c => c.Ingredients).ThenInclude(c => c.Recipe).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _context.Recipes.Include(c => c.Ingredients).ThenInclude(c => c.Recipe).ToListAsync();
        }

        public async Task<Recipe> UpdateRecipe(int id, Recipe recipe)
        {
            Recipe recipeToUpd = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            recipeToUpd.RecipeName = recipe.RecipeName;
            recipeToUpd.RecipeType = recipe.RecipeType;
            recipeToUpd.ImageIrl = recipe.ImageIrl;
            await _context.SaveChangesAsync();
            return await _context.Recipes.Include(c => c.Ingredients).ThenInclude(c => c.Recipe).FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
