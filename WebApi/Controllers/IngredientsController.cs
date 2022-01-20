using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientsController(IIngredientService service) { _service = service; }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredientGroupsByParameters(
            [FromQuery] string? name, [FromQuery] int[]? groupId)
        {
            return await _service.GetIngredientGroupsByParametersAsync(name, groupId);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IngredientDTO>> GetIngredient(int id)
        {
            var ingredient = await _service.GetIngredientAsync(id);

            if (ingredient == null) return NotFound();

            return ingredient;
        }

        // GET: api/Ingredients/Groups/3
        [HttpGet("Groups/{groupId:int}")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredientsByGroupId(int groupId)
        {
            return await _service.GetIngredientsByGroupIdAsync(groupId);
        }

        // GET: api/Ingredients/Ананас
        [HttpGet("{name}")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredientsByName(string name)
        {
            return await _service.GetIngredientsByNameAsync(name);
        }
    }
}
