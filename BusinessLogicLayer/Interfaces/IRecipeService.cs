using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRecipeService : IDisposable
    {
        Task<RecipeDTO> GetRecipeAsync(int id);

        Task<List<RecipeDTO>> GetRecipesAsync();

        Task<List<RecipeDTO>> GetRecipesByNameAsync(string name);

        Task<List<RecipeDTO>> GetRecipesByCuisineIdAsync(int cuisineId);

        Task<List<RecipeDTO>> GetRecipesByCategoryIdAsync(int categoryId);

        Task<List<RecipeDTO>> GetRecipesByAuthorIdAsync(int authorId);

        Task<List<RecipeDTO>> GetRecipesByParametersAsync(
            string? name, int? leftTimeBound, int? rightTimeBound,
            int[]? cuisineIds, int[]? categoryIds, int[]? authorIds);

        Task<bool> AnyRecipesAsync(Expression<Func<Recipe, bool>> expression);

        Task<RecipeDTO> PostRecipeAsync(RecipeDTO dish);

        Task PutRecipeAsync(int id, RecipeDTO dish);

        Task DeleteRecipeAsync(int id);
    }
}
