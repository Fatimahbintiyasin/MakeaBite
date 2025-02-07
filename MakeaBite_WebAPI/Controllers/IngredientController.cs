using AutoMapper;
using MakeaBite_WebAPI.DTOs;
using MakeaBite_WebAPI.Services;
using MakeaBite_Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakeaBite_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet("{recipeId}/ingredients")]

        public async Task<ActionResult<Ingredient>> GetIngredients(int recipeId)
        {
            var ingredientsForRecipe = await _ingredientRepository.GetIngredientsForRecipe(recipeId);
            var ingredientsForRecipeResult = _mapper.Map<IEnumerable<IngredientDto>>(ingredientsForRecipe);

            return Ok(ingredientsForRecipeResult);
        }

        // GET api/<controller>/5

        [HttpGet("{recipeId}/ingredients/{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(int recipeId, int id)
        {
            var ingredients = await _ingredientRepository.GetIngredientsForRecipeById(recipeId, id);

            if (ingredients == null)
            {
                return NotFound();
            }

            var ingredientsResult = _mapper.Map<IngredientDto>(ingredients);
            return Ok(ingredientsResult);
        }

        // POST api/<controller>

        [HttpPost("{recipeId}/ingredients")]
        public async Task<ActionResult<IngredientDto>> CreateIngredient(int recipeId, [FromBody] IngredientWithoutIdDto ingredient)
        {
            if (ingredient == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var finalIngredient = _mapper.Map<Ingredient>(ingredient);

            await _ingredientRepository.AddIngredientsForRecipe(recipeId, finalIngredient);

            if (!await _ingredientRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdIngredientToReturn = _mapper.Map<IngredientDto>(finalIngredient);

            return CreatedAtAction("GetIngredient", new { recipeId = recipeId, id = createdIngredientToReturn.Id }, createdIngredientToReturn);
        }

        // PUT api/<controller>/5

        [HttpPut("{recipeId}/ingredients/{id}")]
        public async Task<ActionResult> UpdateIngredient(int recipeId, int id, [FromBody] IngredientWithoutIdDto ingredient)
        {
            if (ingredient == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            Ingredient oldIngredientEntity = await _ingredientRepository.GetIngredientsForRecipeById(recipeId, id);

            if (ingredient == null) return NotFound();

            _mapper.Map(ingredient, oldIngredientEntity);


            if (!await _ingredientRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE api/<controller>/5

        [HttpDelete("{recipeId}/ingredients/{id}")]
        public async Task<ActionResult> DeleteIngredient(int recipeId, int id)
        {
            Ingredient ingredientEntity2Delete = await _ingredientRepository.GetIngredientsForRecipeById(recipeId, id);

            if (ingredientEntity2Delete == null) return NotFound();

            await _ingredientRepository.DeleteIngredient(ingredientEntity2Delete.Id);

            if (!await _ingredientRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
