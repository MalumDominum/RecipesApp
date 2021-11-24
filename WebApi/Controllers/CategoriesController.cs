using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UnitOfWork _context;

        public CategoriesController() { _context = new UnitOfWork(); }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() => 
            await _context.Categories.GetAllAsync();

        // GET: api/Categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryAsync(int id, Category category)
        {
            var allCategories = await _context.Categories.GetAllAsync();
            if (allCategories.Any(c => c.Name == category.Name))
                return BadRequest("Category with that name already existing");

            if (id != category.Id)
                return BadRequest();

            await _context.Categories.UpdateAsync(category);

            try
            {
                await _context.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool categoryExists = await CategoryExistsAsync(id);
                if (!categoryExists) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var allCategories = await _context.Categories.GetAllAsync();
            if (allCategories.Any(c => c.Name == category.Name))
                return BadRequest("Category with that name already existing");

            await _context.Categories.AddAsync(category);
            await _context.SaveAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await _context.Categories.DeleteAsync(category);
            await _context.SaveAsync();

            return NoContent();
        }

        private async Task<bool> CategoryExistsAsync(int id)
        {
            var categories = await _context.Categories.GetAllAsync();
            return categories.Any(e => e.Id == id);
        }
    }
}
