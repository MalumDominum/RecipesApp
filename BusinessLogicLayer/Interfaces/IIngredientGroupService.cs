using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IIngredientGroupService : IDisposable
    {
        Task<IngredientGroupDTO> GetIngredientGroupAsync(int id);

        Task<List<IngredientGroupDTO>> GetIngredientGroupsAsync();

        Task<bool> AnyIngredientGroupsAsync(Expression<Func<IngredientGroup, bool>> expression);
    }
}
