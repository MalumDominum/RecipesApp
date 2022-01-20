using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using BusinessLogicLayer.Infrastructure;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<RecipeDTO> GetRecipeAsync(int id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);

            return _mapper.Map<RecipeDTO>(recipe);
        }

        public async Task<List<RecipeDTO>> GetRecipesAsync()
        {
            var recipes = await _unitOfWork.Recipes.GetAllAsync();

            return _mapper.Map<List<RecipeDTO>>(recipes);
        }

        public async Task<List<RecipeDTO>> GetRecipesByNameAsync(string name)
        {
            var recipes = await _unitOfWork.Recipes.GetWhereAsync(d =>
                d.Name.ToLower().Contains(name.ToLower())
            );

            return _mapper.Map<List<RecipeDTO>>(recipes);
        }

        public async Task<List<RecipeDTO>> GetRecipesByCategoryIdAsync(int categoryId)
        {
            var recipes = await _unitOfWork.Recipes.GetWhereAsync(d => d.CategoryId == categoryId);

            return _mapper.Map<List<RecipeDTO>>(recipes);
        }

        public async Task<List<RecipeDTO>> GetRecipesByCuisineIdAsync(int cuisineId)
        {
            var recipes = await _unitOfWork.Recipes.GetWhereAsync(d => d.CuisineId == cuisineId);

            return _mapper.Map<List<RecipeDTO>>(recipes);
        }

        public async Task<List<RecipeDTO>> GetRecipesByAuthorIdAsync(int authorId)
        {
            var recipes = await _unitOfWork.Recipes.GetWhereAsync(d => d.AuthorId == authorId);

            return _mapper.Map<List<RecipeDTO>>(recipes);
        }

        public async Task<List<RecipeDTO>> GetRecipesByParametersAsync(
            string? name, int? leftTimeBound, int? rightTimeBound,
            int[]? cuisineIds, int[]? categoryIds, int[]? authorIds)
        {
            var queryable = _unitOfWork.Recipes.GetQueryable();

            if (!string.IsNullOrEmpty(name))
                queryable = queryable.Where(r => r.Name.ToLower().Contains(name.ToLower()));

            if (leftTimeBound != null)
                queryable = queryable.Where(r => r.CookingTime >= leftTimeBound);

            if (rightTimeBound != null)
                queryable = queryable.Where(r => r.CookingTime <= rightTimeBound);

            if (cuisineIds is { Length: > 0 })
                queryable = queryable.Where(r => cuisineIds.Contains(r.CuisineId));

            if (categoryIds is { Length: > 0 })
                queryable = queryable.Where(r => categoryIds.Contains(r.CategoryId));

            if (authorIds is { Length: > 0 })
                queryable = queryable.Where(r => authorIds.Contains(r.AuthorId));

            return _mapper.Map<List<RecipeDTO>>(await queryable.ToListAsync());
        }

        public async Task<bool> AnyRecipesAsync(Expression<Func<Recipe, bool>> expression)
        {
            return await _unitOfWork.Recipes.AnyExistingAsync(expression);
        }

        public async Task<RecipeDTO> PostRecipeAsync(RecipeDTO recipe)
        {
            var recipeAdded = _mapper.Map<RecipeDTO>(
                    await _unitOfWork.Recipes.AddAsync(_mapper.Map<Recipe>(recipe))
                );
            await _unitOfWork.SaveAsync();
            return recipeAdded;
        }

        public async Task PutRecipeAsync(int id, RecipeDTO recipe)
        {
            await _unitOfWork.Recipes.UpdateAsync(_mapper.Map<Recipe>(recipe));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
            if (recipe == null) throw new KeyNotFoundException();

            await _unitOfWork.Recipes.DeleteAsync(recipe);
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