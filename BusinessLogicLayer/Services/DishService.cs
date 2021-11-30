using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer;

namespace BusinessLogicLayer.Services
{
    public class DishService : IDishService
    {
        private readonly UnitOfWork _unitOfWork;
        //private readonly IPortionDistributor _portionDistributor;

        private bool _disposed = false;

        public DishService()  //(IPortionDistributor portionDistributor) 
        {
            _unitOfWork = new UnitOfWork();
            //_portionDistributor = portionDistributor;
        }

        public async Task<DishDTO> GetDish(int id)
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

        public async Task<List<DishDTO>> GetDishes()
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

        public async Task<List<DishDTO>> GetDishesByCategory(int categoryId)
        {
            var dishes = await _unitOfWork.Dishes.GetAllByCategoryAsync(categoryId);

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

        public async Task<List<DishDTO>> GetDishesByCuisine(int cuisineId)
        {
            var dishes = await _unitOfWork.Dishes.GetAllByCuisineAsync(cuisineId);

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

        public async Task PostDish(DishDTO dish)
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

        //// Breaking SRP...
        //public async Task PostDishWithPortions(DishDTO dish, DishPortionDTO portion, double[] coefficients)
        //{
        //    await _unitOfWork.Dishes.AddAsync(new Dish
        //    {
        //        Id = dish.Id,
        //        Name = dish.Name,
        //        Description = dish.Description,
        //        CuisineId = dish.CuisineId,
        //        CategoryId = dish.CategoryId,
        //    });
        //    var portions = _portionDistributor.DistributePortions(portion, coefficients);

        //    foreach (var p in portions)
        //        await _unitOfWork.DishPortions.AddAsync(new DishPortion
        //        {
        //            Id = p.Id,
        //            Cost = p.Cost,
        //            Weight = p.Weight,
        //            Calories = p.Calories,
        //            Proteins = p.Proteins,
        //            Fats = p.Fats,
        //            Carbs = p.Carbs,
        //            DishId = dish.Id
        //        });

        //    await _unitOfWork.SaveAsync();
        //}

        //// Breaking SRP...
        //public async Task PostDishWithPortions(DishDTO dish, List<DishPortionDTO> portions)
        //{
        //    await _unitOfWork.Dishes.AddAsync(new Dish
        //    {
        //        Id = dish.Id,
        //        Name = dish.Name,
        //        Description = dish.Description,
        //        CuisineId = dish.CuisineId,
        //        CategoryId = dish.CategoryId
        //    });

        //    foreach (var p in portions)
        //        await _unitOfWork.DishPortions.AddAsync(new DishPortion
        //        {
        //            Id = p.Id,
        //            Cost = p.Cost,
        //            Weight = p.Weight,
        //            Calories = p.Calories,
        //            Proteins = p.Proteins,
        //            Fats = p.Fats,
        //            Carbs = p.Carbs,
        //            DishId = dish.Id
        //        });

        //    await _unitOfWork.SaveAsync();
        //}

        public async Task PutDish(int id, DishDTO dish)
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

        public async Task DeleteDish(int id)
        {
            var dish = await _unitOfWork.Dishes.GetByIdAsync(id);
            if (dish == null) throw new Exception();

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