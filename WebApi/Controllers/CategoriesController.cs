using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) { _service = service; }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories() => await _service.GetCategoriesAsync();

        // GET: api/Categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _service.GetCategoryAsync(id);

            if (category == null) return NotFound();

            return category;
        }
    }
}
