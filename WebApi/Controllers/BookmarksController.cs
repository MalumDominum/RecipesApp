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
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkService _service;

        public BookmarksController(IBookmarkService service) { _service = service; }

        // GET: api/Bookmarks
        [HttpGet]
        public async Task<ActionResult<List<BookmarkDTO>>> GetBookmarks() => await _service.GetBookmarksAsync();

        // GET: api/Bookmarks/Users/5
        [HttpGet("Users/{userId:int}")]
        public async Task<ActionResult<List<BookmarkDTO>>> GetBookmarksByUserId(int userId)
        {
            return await _service.GetBookmarksByUserIdAsync(userId);
        }

        // GET: api/Bookmarks/Recipes/3
        [HttpGet("Recipes/{recipeId:int}")]
        public async Task<ActionResult<List<BookmarkDTO>>> GetBookmarksByRecipeId(int recipeId)
        {
            return await _service.GetBookmarksByRecipeIdAsync(recipeId);
        }

        // POST: api/Bookmarks
        [HttpPost]
        public async Task<ActionResult<BookmarkDTO>> PostBookmark(BookmarkDTO bookmark)
        {
            if (await _service.AnyBookmarksAsync(x => x.RecipeId == bookmark.RecipeId &&
                                                      x.UserId == bookmark.UserId))
                return BadRequest("Bookmark with that identities already existing");

            await _service.PostBookmarkAsync(bookmark);

            return CreatedAtAction(nameof(GetBookmarks),
                new { recipeId = bookmark.RecipeId, userId = bookmark.UserId }, bookmark);
        }

        /* TODO Uncomment when made bookmark collections
        // PUT: api/Bookmarks
        [HttpPut]
        public async Task<IActionResult> PutBookmarkAsync(BookmarkDTO bookmark)
        {
            await _service.PutBookmarkAsync(bookmark);
            return NoContent();
        }*/

        // DELETE: api/Bookmarks?userId=3&recipeId=5
        [HttpDelete]
        public async Task<IActionResult> DeleteBookmark(int userId, int recipeId)
        {
            if (!await _service.AnyBookmarksAsync(b => b.UserId == userId &&
                                                       b.RecipeId == recipeId))
                return NotFound();

            await _service.DeleteBookmarkAsync(userId, recipeId);

            return NoContent();
        }
    }
}
