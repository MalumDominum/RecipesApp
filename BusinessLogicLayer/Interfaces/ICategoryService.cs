using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<CategoryDTO> GetCategoryAsync(int id);

        Task<List<CategoryDTO>> GetCategoriesAsync();

        Task<bool> AnyCategoriesAsync(Expression<Func<Category, bool>> expression);
    }
}
