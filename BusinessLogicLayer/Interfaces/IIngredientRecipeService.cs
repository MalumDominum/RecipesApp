using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IIngredientRecipeService : IDisposable
    {
        Task<List<IngredientRecipeDTO>> GetIngredientRecipeAsync();

        Task<List<IngredientRecipeDTO>> GetIngredientRecipeByIngredientIdAsync(int ingredientId);

        Task<List<IngredientRecipeDTO>> GetIngredientRecipeByRecipeIdAsync(int recipeId);

        Task<bool> AnyIngredientRecipeAsync(Expression<Func<IngredientRecipe, bool>> expression);

        Task PostIngredientRecipeAsync(IngredientRecipeDTO ingredientRecipe);

        Task PutIngredientRecipeAsync(IngredientRecipeDTO ingredientRecipe);

        Task DeleteIngredientRecipeAsync(int ingredientId, int recipeId);
    }
}
