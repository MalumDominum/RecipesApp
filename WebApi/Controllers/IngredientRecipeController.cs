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
    public class IngredientRecipeController : ControllerBase
    {
        private readonly IIngredientRecipeService _service;

        public IngredientRecipeController(IIngredientRecipeService service) { _service = service; }

        // GET: api/IngredientRecipe
        [HttpGet]
        public async Task<ActionResult<List<IngredientRecipeDTO>>> GetIngredientRecipes()
        {
            return await _service.GetIngredientRecipeAsync();
        }

        // GET: api/IngredientRecipe/Ingredients/5
        [HttpGet("Ingredients/{ingredientId:int}")]
        public async Task<ActionResult<List<IngredientRecipeDTO>>> GetIngredientRecipesByIngredientId(int ingredientId)
        {
            return await _service.GetIngredientRecipeByIngredientIdAsync(ingredientId);
        }

        // GET: api/IngredientRecipe/Recipes/3
        [HttpGet("Recipes/{recipeId:int}")]
        public async Task<ActionResult<List<IngredientRecipeDTO>>> GetIngredientRecipesByRecipeId(int recipeId)
        {
            return await _service.GetIngredientRecipeByRecipeIdAsync(recipeId);
        }

        // POST: api/IngredientRecipe
        [HttpPost]
        public async Task<ActionResult<IngredientRecipeDTO>> PostIngredientRecipe(IngredientRecipeDTO ingredientRecipe)
        {
            if (await _service.AnyIngredientRecipeAsync(x => x.IngredientId == ingredientRecipe.IngredientId &&
                                                             x.RecipeId == ingredientRecipe.RecipeId))
                return BadRequest("IngredientRecipe with that identities already existing");

            await _service.PostIngredientRecipeAsync(ingredientRecipe);

            return CreatedAtAction(
                nameof(GetIngredientRecipes),
                new { ingredientId = ingredientRecipe.IngredientId, recipeId = ingredientRecipe.RecipeId },
                ingredientRecipe);
        }
        
        // PUT: api/IngredientRecipe
        [HttpPut]
        public async Task<IActionResult> PutIngredientRecipeAsync(IngredientRecipeDTO ingredientRecipe)
        {
            await _service.PutIngredientRecipeAsync(ingredientRecipe);
            return NoContent();
        }

        // DELETE: api/IngredientRecipe?ingredientId=3&recipeId=5
        [HttpDelete]
        public async Task<IActionResult> DeleteIngredientRecipe(int ingredientId, int recipeId)
        {
            if (!await _service.AnyIngredientRecipeAsync(x => x.IngredientId == ingredientId &&
                                                              x.RecipeId == recipeId))
                return NotFound();

            await _service.DeleteIngredientRecipeAsync(ingredientId, recipeId);

            return NoContent();
        }
    }
}
