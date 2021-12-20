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
    public class IngredientGroupsController : ControllerBase
    {
        private readonly IIngredientGroupService _service;

        public IngredientGroupsController(IIngredientGroupService service) { _service = service; }

        // GET: api/IngredientGroups
        [HttpGet]
        public async Task<ActionResult<List<IngredientGroupDTO>>> GetIngredientGroups() =>
            await _service.GetIngredientGroupsAsync();

        // GET: api/IngredientGroups/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IngredientGroupDTO>> GetIngredientGroup(int id)
        {
            var ingredientGroup = await _service.GetIngredientGroupAsync(id);

            if (ingredientGroup == null) return NotFound();

            return ingredientGroup;
        }
    }
}
