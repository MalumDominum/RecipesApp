using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICuisineService : IDisposable
    {
        Task<CuisineDTO> GetCuisineAsync(int id);

        Task<List<CuisineDTO>> GetCuisinesAsync();

        Task<bool> AnyCuisinesAsync(Expression<Func<Cuisine, bool>> expression);
    }
}
