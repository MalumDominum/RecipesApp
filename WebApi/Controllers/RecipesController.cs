using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service) { _service = service; }

        // GET: api/Recipes?name=Манная каша&categoryId=3&categoryId=7&authorId=1
        [HttpGet]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipes(
            [FromQuery] string? name, [FromQuery] int? leftTimeBound, [FromQuery] int? rightTimeBound,
            [FromQuery] int[]? cuisineId, [FromQuery] int[]? categoryId, [FromQuery] int[]? authorId)
        {
            return await _service.GetRecipesByParametersAsync(
                name, leftTimeBound, rightTimeBound, cuisineId, categoryId, authorId);
        }

        // GET: api/Recipes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            var recipe = await _service.GetRecipeAsync(id);

            if (recipe == null) return NotFound();

            return recipe;
        }

        // GET: api/Recipes/Манная каша
        [HttpGet("{name}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipesByName(string name)
        {
            return await _service.GetRecipesByNameAsync(name);
        }

        // GET: api/Recipes/Categories/3
        [HttpGet("Categories/{categoryId:int}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipesByCategoryId(int categoryId)
        {
            return await _service.GetRecipesByCategoryIdAsync(categoryId);
        }

        // GET: api/Recipes/Cuisine/3
        [HttpGet("Cuisines/{cuisineId:int}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipesByCuisineId(int cuisineId)
        {
            return await _service.GetRecipesByCuisineIdAsync(cuisineId);
        }

        // GET: api/Recipes/Authors/3
        [HttpGet("Authors/{authorId:int}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipesByAuthorId(int authorId)
        {
            return await _service.GetRecipesByAuthorIdAsync(authorId);
        }

        // POST: api/Recipes
        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> PostRecipe(RecipeDTO recipe)
        {
            await _service.PostRecipeAsync(recipe);

            var recipeAdded = (await _service.GetRecipesByParametersAsync(
                    recipe.Name,
                    recipe.CookingTime, recipe.CookingTime,
                    new[] { recipe.CuisineId }, 
                    new[] { recipe.CategoryId },
                    new[] { recipe.AuthorId })
                ).First();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipeAdded.Id }, recipeAdded);
        }

        // PUT: api/Recipes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutRecipeAsync(int id, RecipeDTO recipe)
        {
            if (id != recipe.Id)
                return BadRequest("Recipe must have the same id in header and body");

            await _service.PutRecipeAsync(id, recipe);
            return NoContent();
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (!await _service.AnyRecipesAsync(d => d.Id == id))
                return NotFound();

            await _service.DeleteRecipeAsync(id);

            return NoContent();
        }
    }
}
