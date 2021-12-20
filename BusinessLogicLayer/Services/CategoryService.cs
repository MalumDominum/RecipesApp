using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetCategoryAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<bool> AnyCategoriesAsync(Expression<Func<Category, bool>> expression)
        {
            return await _unitOfWork.Categories.AnyExistingAsync(expression);
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