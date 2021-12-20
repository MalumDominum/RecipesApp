using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGradeService : IDisposable
    {
        Task<List<GradeDTO>> GetGradesAsync();

        Task<List<GradeDTO>> GetGradesByUserIdAsync(int userId);

        Task<List<GradeDTO>> GetGradesByRecipeIdAsync(int recipeId);

        Task<bool> AnyGradesAsync(Expression<Func<Grade, bool>> expression);

        Task PostGradeAsync(GradeDTO bookmark);
    }
}
