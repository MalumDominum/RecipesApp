using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDishService : IDisposable
    {
        Task<DishDTO> GetDishAsync(int id);

        Task<List<DishDTO>> GetDishesAsync();

        Task<List<DishDTO>> GetDishesByCuisineIdAsync(int cuisineId);

        Task<List<DishDTO>> GetDishesByCategoryIdAsync(int categoryId);

        Task<bool> AnyDishesAsync(Expression<Func<Dish, bool>> expression);

        Task PostDishAsync(DishDTO dish);

        Task PutDishAsync(int id, DishDTO dish);

        Task DeleteDishAsync(int id);
    }
}
