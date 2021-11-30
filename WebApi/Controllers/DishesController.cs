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
        public async Task<ActionResult<List<DishDTO>>> GetDishes() => await _service.GetDishes();

        // GET: api/Dishes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DishDTO>> GetDish(int id)
        {
            var dish = await _service.GetDish(id);

            if (dish == null) return NotFound();

            return dish;
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishAsync(int id, DishDTO dish)
        {
            var allDishes = await _service.GetDishes();
            if (allDishes.Any(c => c.Name == dish.Name && c.Id != id))
                return BadRequest("Dish with that name already existing");

            if (id != dish.Id)
                return BadRequest("Dish must have same id with id in header");

            await _service.PutDish(id, dish);
            return NoContent();
        }

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishDTO>> PostDish(DishDTO dish)
        {
            var allDishes = await _service.GetDishes();
            if (allDishes.Any(c => c.Name == dish.Name))
                return BadRequest("Dish with that name already existing");
            // Make same with categoryId and cuisineId

            await _service.PostDish(dish);

            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var dishExists = await DishExistsAsync(id);
            if (!dishExists) return NotFound();

            await _service.DeleteDish(id);

            return NoContent();
        }

        private async Task<bool> DishExistsAsync(int id)
        {
            var categories = await _service.GetDishes();
            return categories.Any(e => e.Id == id);
        }
    }
}
