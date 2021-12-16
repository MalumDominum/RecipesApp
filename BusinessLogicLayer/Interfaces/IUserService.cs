using System.Threading.Tasks;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);

    Task<List<User>> GetUsersAsync();

    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);

    Task<AuthenticateResponse> RegisterAsync(UserDTO userModel);
}
