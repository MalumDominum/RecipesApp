using AutoMapper;
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
        private readonly IMapper _mapper;

        public DishService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<DishDTO> GetDishAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.GetByIdAsync(id);

            return _mapper.Map<DishDTO>(dish);
        }

        public async Task<List<DishDTO>> GetDishesAsync()
        {
            var dishes = await _unitOfWork.Dishes.GetAllAsync();

            return _mapper.Map<List<DishDTO>>(dishes);
        }

        public async Task<List<DishDTO>> GetDishesByCategoryIdAsync(int categoryId)
        {
            var dishes = await _unitOfWork.Dishes.GetWhereAsync(d => d.CategoryId == categoryId);

            return _mapper.Map<List<DishDTO>>(dishes);
        }

        public async Task<List<DishDTO>> GetDishesByCuisineIdAsync(int cuisineId)
        {
            var dishes = await _unitOfWork.Dishes.GetWhereAsync(d => d.CuisineId == cuisineId);

            return _mapper.Map<List<DishDTO>>(dishes);
        }

        //public async Task<bool> AnyDishesAsync(Expression<Func<Dish, bool>> expression)
        //{
        //    return await _unitOfWork.Dishes.AnyExistingAsync(expression);
        //}

        public async Task PostDishAsync(DishDTO dish)
        {
            await _unitOfWork.Dishes.AddAsync(_mapper.Map<Dish>(dish));
            await _unitOfWork.SaveAsync();
        }

        public async Task PutDishAsync(int id, DishDTO dish)
        {
            await _unitOfWork.Dishes.UpdateAsync(_mapper.Map<Dish>(dish));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDishAsync(int id)
        {
            var dish = await _unitOfWork.Dishes.GetByIdAsync(id);
            if (dish == null) throw new KeyNotFoundException();

            await _unitOfWork.Dishes.DeleteAsync(dish);
            await _unitOfWork.SaveAsync();
        }

        private bool _disposed = false;

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