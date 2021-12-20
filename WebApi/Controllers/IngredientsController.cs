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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientsController(IIngredientService service) { _service = service; }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredients() => await _service.GetIngredientsAsync();

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
    }
}
