using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BusinessLogicLayer.Interfaces;
using RecipesMvcApp.Models;

namespace RecipesMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service, ILogger<RecipesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _service.GetRecipesAsync();

            return View(recipes);
        }

        public async Task<IActionResult> Recipe(int id)
        {
            var recipe = await _service.GetRecipeAsync(id);

            return recipe != null ? View(recipe) : View("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}