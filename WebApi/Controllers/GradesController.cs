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
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _service;

        public GradesController(IGradeService service) { _service = service; }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<List<GradeDTO>>> GetGrades() => await _service.GetGradesAsync();

        // GET: api/Grades/Users/5
        [HttpGet("Users/{userId:int}")]
        public async Task<ActionResult<List<GradeDTO>>> GetGradesByUserId(int userId)
        {
            return await _service.GetGradesByUserIdAsync(userId);
        }

        // GET: api/Grades/Recipes/3
        [HttpGet("Recipes/{recipeId:int}")]
        public async Task<ActionResult<List<GradeDTO>>> GetGradesByRecipeId(int recipeId)
        {
            return await _service.GetGradesByRecipeIdAsync(recipeId);
        }

        // POST: api/Grades
        [HttpPost]
        public async Task<ActionResult<GradeDTO>> PostGrade(GradeDTO grade)
        {
            if (await _service.AnyGradesAsync(x => x.RecipeId == grade.RecipeId &&
                                                      x.UserId == grade.UserId))
                return BadRequest("Grade with that identities already existing");

            await _service.PostGradeAsync(grade);

            return CreatedAtAction(nameof(GetGrades),
                new { recipeId = grade.RecipeId, userId = grade.UserId }, grade);
        }
    }
}
