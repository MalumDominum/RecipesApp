using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<IngredientDTO> GetIngredientAsync(int id)
        {
            var ingredient = await _unitOfWork.Ingredients.GetByIdAsync(id);

            return _mapper.Map<IngredientDTO>(ingredient);
        }

        public async Task<List<IngredientDTO>> GetIngredientsAsync()
        {
            var ingredients = await _unitOfWork.Ingredients.GetAllAsync();

            return _mapper.Map<List<IngredientDTO>>(ingredients);
        }

        public async Task<List<IngredientDTO>> GetIngredientsByGroupIdAsync(int groupId)
        {
            var ingredients = await _unitOfWork.Ingredients.GetWhereAsync(d => d.GroupId == groupId);

            return _mapper.Map<List<IngredientDTO>>(ingredients);
        }

        public async Task<List<IngredientDTO>> GetIngredientsByNameAsync(string name)
        {
            var ingredients = await _unitOfWork.Ingredients.GetWhereAsync(d =>
                    d.Name.ToLower().Contains(name.ToLower())
                );

            return _mapper.Map<List<IngredientDTO>>(ingredients);
        }

        public async Task<bool> AnyIngredientsAsync(Expression<Func<Ingredient, bool>> expression)
        {
            return await _unitOfWork.Ingredients.AnyExistingAsync(expression);
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _unitOfWork.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}