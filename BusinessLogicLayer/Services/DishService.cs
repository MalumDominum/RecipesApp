using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;

        private bool _disposed = false;

        public DishService(IUoWFactory uowFactory)
        {
            _unitOfWork = uowFactory.CreateUoW();
        }

        public async Task<DishDTO> GetDishAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.GetByIdAsync(id);

            return new DishDTO
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                CategoryId = dish.CategoryId,
                CuisineId = dish.CuisineId
            };
        }

        public async Task<List<DishDTO>> GetDishesAsync()
        {
            var dishes = await _unitOfWork.Dishes.GetAllAsync();

            var result = new List<DishDTO>();
            foreach (var dish in dishes)
                result.Add(new DishDTO
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    CategoryId = dish.CategoryId,
                    CuisineId = dish.CuisineId
                });
            return result;
        }

        public async Task<List<DishDTO>> GetDishesByCategoryIdAsync(int categoryId)
        {
            var dishes = await _unitOfWork.Dishes.GetWhereAsync(d => d.CategoryId == categoryId);

            var result = new List<DishDTO>();
            foreach (var dish in dishes)
                result.Add(new DishDTO
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    CategoryId = dish.CategoryId,
                    CuisineId = dish.CuisineId
                });
            return result;
        }

        public async Task<List<DishDTO>> GetDishesByCuisineIdAsync(int cuisineId)
        {
            var dishes = await _unitOfWork.Dishes.GetWhereAsync(d => d.CuisineId == cuisineId);

            var result = new List<DishDTO>();
            foreach (var dish in dishes)
                result.Add(new DishDTO
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    CategoryId = dish.CategoryId,
                    CuisineId = dish.CuisineId
                });
            return result;
        }

        public async Task<bool> AnyDishesAsync(Expression<Func<Dish, bool>> expression)
        {
            return await _unitOfWork.Dishes.AnyExistingAsync(expression);
        }

        public async Task PostDishAsync(DishDTO dish)
        {
            await _unitOfWork.Dishes.AddAsync(new Dish
            {
                Id = dish.Id, 
                Name = dish.Name,
                Description = dish.Description,
                CuisineId = dish.CuisineId,
                CategoryId = dish.CategoryId,
            });
            await _unitOfWork.SaveAsync();
        }

        public async Task PutDishAsync(int id, DishDTO dish)
        {
            await _unitOfWork.Dishes.UpdateAsync(new Dish
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                CuisineId = dish.CuisineId,
                CategoryId = dish.CategoryId
            });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDishAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.GetByIdAsync(id);
            if (dish == null) throw new KeyNotFoundException();

            await _unitOfWork.Dishes.DeleteAsync(dish);
            await _unitOfWork.SaveAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _unitOfWork.Dispose();

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}