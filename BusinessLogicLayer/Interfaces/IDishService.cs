using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDishService : IDisposable
    {
        Task<DishDTO> GetDish(int id);

        Task<List<DishDTO>> GetDishes();

        Task<List<DishDTO>> GetDishesByCuisine(int cuisineId);

        Task<List<DishDTO>> GetDishesByCategory(int categoryId);

        Task PostDish(DishDTO dish);

        //Task PostDishWithPortions(DishDTO dish, DishPortionDTO portion, double[] coefficients);

        //Task PostDishWithPortions(DishDTO dish, List<DishPortionDTO> portions);

        Task PutDish(int id, DishDTO dish);

        Task DeleteDish(int id);
    }
}
