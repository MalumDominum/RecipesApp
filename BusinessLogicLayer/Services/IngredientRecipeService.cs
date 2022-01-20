using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using BusinessLogicLayer.Infrastructure;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class IngredientRecipeService : IIngredientRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientRecipeService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }
        public async Task<List<IngredientRecipeDTO>> GetIngredientRecipeAsync()
        {
            var pairs = await _unitOfWork.IngredientRecipe.GetAllAsync();

            return _mapper.Map<List<IngredientRecipeDTO>>(pairs);
        }

        public async Task<List<IngredientRecipeDTO>> GetIngredientRecipeByIngredientIdAsync(int ingredientId)
        {
            var pairs = await _unitOfWork.IngredientRecipe.GetWhereAsync(ir => ir.IngredientId == ingredientId);

            return _mapper.Map<List<IngredientRecipeDTO>>(pairs);
        }

        public async Task<List<IngredientRecipeDTO>> GetIngredientRecipeByRecipeIdAsync(int recipeId)
        {
            var pairs = await _unitOfWork.IngredientRecipe.GetWhereAsync(ir => ir.RecipeId == recipeId);

            return _mapper.Map<List<IngredientRecipeDTO>>(pairs);
        }

        public async Task<bool> AnyIngredientRecipeAsync(Expression<Func<IngredientRecipe, bool>> expression)
        {
            return await _unitOfWork.IngredientRecipe.AnyExistingAsync(expression);
        }

        public async Task PostIngredientRecipeAsync(IngredientRecipeDTO ingredientRecipe)
        {
            await _unitOfWork.IngredientRecipe.AddAsync(_mapper.Map<IngredientRecipe>(ingredientRecipe));
            await _unitOfWork.SaveAsync();
        }

        public async Task PutIngredientRecipeAsync(IngredientRecipeDTO ingredientRecipe)
        {
            await _unitOfWork.IngredientRecipe.UpdateAsync(_mapper.Map<IngredientRecipe>(ingredientRecipe));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteIngredientRecipeAsync(int ingredientId, int recipeId)
        {
            var ingredientRecipe = await _unitOfWork.IngredientRecipe
                .GetFirstOrDefaultAsync(ir => ir.IngredientId == ingredientId &&
                                              ir.RecipeId == recipeId);
            if (ingredientRecipe == null) throw new KeyNotFoundException();

            await _unitOfWork.IngredientRecipe.DeleteAsync(ingredientRecipe);
            await _unitOfWork.SaveAsync();
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