using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly ICuisineService _service;

        public CuisinesController(ICuisineService service) { _service = service; }

        // GET: api/Cuisines
        [HttpGet]
        public async Task<ActionResult<List<CuisineDTO>>> GetCuisines() => await _service.GetCuisinesAsync();

        // GET: api/Cuisines/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CuisineDTO>> GetCuisine(int id)
        {
            var cuisine = await _service.GetCuisineAsync(id);

            if (cuisine == null) return NotFound();

            return cuisine;
        }
    }
}
