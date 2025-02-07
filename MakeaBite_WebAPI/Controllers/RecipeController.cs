using AutoMapper;
using MakeaBite_WebAPI.DTOs;
using MakeaBite_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MakeaBite_Library.Models;

namespace MakeaBite_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipes();
            var results = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipeById(int id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);
            var result = _mapper.Map<RecipeDto>(recipe);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(Recipe recipe)
        {
            var recipeNew = await _recipeRepository.CreateRecipe(recipe);
            var result = _mapper.Map<RecipeDto>(recipeNew);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _recipeRepository.DeleteRecipe(id);
            return Ok();
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<RecipeDto>> UpdateRecipe(int id, Recipe recipe)
        {
            var recipeUpd = await _recipeRepository.UpdateRecipe(id, recipe);
            var result = _mapper.Map<RecipeDto>(recipeUpd);
            return Ok(result);
        }
    }
}
