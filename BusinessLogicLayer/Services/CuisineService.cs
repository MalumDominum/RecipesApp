using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using BusinessLogicLayer.Infrastructure;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class CuisineService : ICuisineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuisineService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }

        public async Task<CuisineDTO> GetCuisineAsync(int id)
        {
            var cuisine = await _unitOfWork.Cuisines.GetByIdAsync(id);

            return _mapper.Map<CuisineDTO>(cuisine);
        }

        public async Task<List<CuisineDTO>> GetCuisinesAsync()
        {
            var cuisines = await _unitOfWork.Cuisines.GetAllAsync();

            return _mapper.Map<List<CuisineDTO>>(cuisines);
        }

        public async Task<bool> AnyCuisinesAsync(Expression<Func<Cuisine, bool>> expression)
        {
            return await _unitOfWork.Cuisines.AnyExistingAsync(expression);
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