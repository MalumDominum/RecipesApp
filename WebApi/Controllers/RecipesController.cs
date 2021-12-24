using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service) { _service = service; }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipes() => await _service.GetRecipesAsync();

        // GET: api/Recipes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            var recipe = await _service.GetRecipeAsync(id);

            if (recipe == null) return NotFound();

            return recipe;
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

        // GET: api/Recipes/Манная каша
        [HttpGet("{name}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipesByName(string name)
        {
            return await _service.GetRecipesByNameAsync(name);
        }

        // POST: api/Recipes
        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> PostRecipe(RecipeDTO recipe)
        {
            if (await _service.AnyRecipesAsync(x => x.Name == recipe.Name))
                return BadRequest("Recipe with that name already existing");

            await _service.PostRecipeAsync(recipe);

            var recipeAdded = (await _service.GetRecipesByNameAsync(recipe.Name)).First();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipeAdded.Id }, recipeAdded);
        }

        // PUT: api/Recipes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutRecipeAsync(int id, RecipeDTO recipe)
        {
            if (await _service.AnyRecipesAsync(c => c.Name == recipe.Name && c.Id != id))
                return BadRequest("Another recipe with that name already existing");

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
