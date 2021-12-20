using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GradeService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }
        public async Task<List<GradeDTO>> GetGradesAsync()
        {
            var grades = await _unitOfWork.Grades.GetAllAsync();

            return _mapper.Map<List<GradeDTO>>(grades);
        }

        public async Task<List<GradeDTO>> GetGradesByUserIdAsync(int userId)
        {
            var grades = await _unitOfWork.Grades.GetWhereAsync(ir => ir.UserId == userId);

            return _mapper.Map<List<GradeDTO>>(grades);
        }

        public async Task<List<GradeDTO>> GetGradesByRecipeIdAsync(int recipeId)
        {
            var grades = await _unitOfWork.Grades.GetWhereAsync(ir => ir.RecipeId == recipeId);

            return _mapper.Map<List<GradeDTO>>(grades);
        }

        public async Task<bool> AnyGradesAsync(Expression<Func<Grade, bool>> expression)
        {
            return await _unitOfWork.Grades.AnyExistingAsync(expression);
        }

        public async Task PostGradeAsync(GradeDTO grade)
        {
            await _unitOfWork.Grades.AddAsync(_mapper.Map<Grade>(grade));
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