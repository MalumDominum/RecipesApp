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
    public class DishesController : ControllerBase
    {
        private readonly IDishService _service;

        public DishesController(IDishService service) { _service = service; }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<List<DishDTO>>> GetDishes() => await _service.GetDishesAsync();

        // GET: api/Dishes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DishDTO>> GetDish(int id)
        {
            var dish = await _service.GetDishAsync(id);

            if (dish == null) return NotFound();

            return dish;
        }

        // GET: api/Dishes/Categories/3
        [HttpGet("Categories/{categoryId:int}")]
        public async Task<ActionResult<List<DishDTO>>> GetDishesByCategoryId(int categoryId)
        {
            return await _service.GetDishesByCategoryIdAsync(categoryId);
        }

        // GET: api/Dishes/Cuisine/3
        [HttpGet("Cuisines/{cuisineId:int}")]
        public async Task<ActionResult<List<DishDTO>>> GetDishesByCuisineId(int cuisineId)
        {
            return await _service.GetDishesByCuisineIdAsync(cuisineId);
        }

        // PUT: api/Dishes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDishAsync(int id, DishDTO dish)
        {
            if (await _service.AnyDishesAsync(c => c.Name == dish.Name && c.Id != id))
                return BadRequest("Another dish with that name already existing");

            if (id != dish.Id)
                return BadRequest("Dish must have same in header and body");

            await _service.PutDishAsync(id, dish);
            return NoContent();
        }

        // POST: api/Dishes
        [HttpPost]
        public async Task<ActionResult<DishDTO>> PostDish(DishDTO dish)
        {
            var allDishes = await _service.GetDishesAsync();
            if (allDishes.Any(c => c.Name == dish.Name))
                return BadRequest("Dish with that name already existing");
            // Make same with categoryId and cuisineId

            await _service.PostDishAsync(dish);

            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            if (!await _service.AnyDishesAsync(d => d.Id == id))
                return NotFound();

            await _service.DeleteDishAsync(id);

            return NoContent();
        }
    }
}
