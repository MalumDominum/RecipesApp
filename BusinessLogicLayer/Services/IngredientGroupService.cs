using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using BusinessLogicLayer.Infrastructure;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class IngredientGroupService : IIngredientGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientGroupService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<IngredientGroupDTO> GetIngredientGroupAsync(int id)
        {
            var group = await _unitOfWork.IngredientGroups.GetByIdAsync(id);

            return _mapper.Map<IngredientGroupDTO>(group);
        }

        public async Task<List<IngredientGroupDTO>> GetIngredientGroupsAsync()
        {
            var groups = await _unitOfWork.IngredientGroups.GetAllAsync();

            return _mapper.Map<List<IngredientGroupDTO>>(groups);
        }

        public async Task<bool> AnyIngredientGroupsAsync(Expression<Func<IngredientGroup, bool>> expression)
        {
            return await _unitOfWork.IngredientGroups.AnyExistingAsync(expression);
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