using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRecipeService : IDisposable
    {
        Task<RecipeDTO> GetRecipeAsync(int id);

        Task<List<RecipeDTO>> GetRecipesAsync();

        Task<List<RecipeDTO>> GetRecipesByCuisineIdAsync(int cuisineId);

        Task<List<RecipeDTO>> GetRecipesByCategoryIdAsync(int categoryId);

        Task<bool> AnyRecipesAsync(Expression<Func<Recipe, bool>> expression);

        Task PostRecipeAsync(RecipeDTO dish);

        Task PutRecipeAsync(int id, RecipeDTO dish);

        Task DeleteRecipeAsync(int id);
    }
}
