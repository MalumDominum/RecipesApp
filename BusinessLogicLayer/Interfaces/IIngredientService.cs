using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IIngredientService : IDisposable
    {
        Task<IngredientDTO> GetIngredientAsync(int id);

        Task<List<IngredientDTO>> GetIngredientsAsync();

        Task<List<IngredientDTO>> GetIngredientsByGroupIdAsync(int groupId);

        Task<List<IngredientDTO>> GetIngredientsByNameAsync(string name);

        Task<List<IngredientDTO>> GetIngredientGroupsByParametersAsync(string? name, int[]? groupIds);

        Task<bool> AnyIngredientsAsync(Expression<Func<Ingredient, bool>> expression);
    }
}
