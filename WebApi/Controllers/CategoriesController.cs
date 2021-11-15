using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary;
using EFDataAccessLibrary.Models;

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
        public ActionResult<IEnumerable<Category>> GetCategories() => Ok(_context.Categories.GetAll());

        // GET: api/Categories/5
        [HttpGet("{id:int}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.Categories.Get(id);

            if (category == null)
                return NotFound();

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (_context.Categories.GetAll().Any(c => c.Name == category.Name))
                return BadRequest("Category with that name already existing");

            _context.Categories.Update(category);

            try
            {
                _context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            if (_context.Categories.GetAll().Any(c => c.Name == category.Name))
                return BadRequest("Category with that name already existing");

            _context.Categories.Create(category);
            _context.Save();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Get(id);
            if (category == null)
                return NotFound();

            _context.Categories.Delete(category.Id);
            _context.Save();

            return NoContent();
        }

        private bool CategoryExists(int id) => _context.Categories.GetAll().Any(e => e.Id == id);
    }
}
