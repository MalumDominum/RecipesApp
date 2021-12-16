using System.Threading.Tasks;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Interfaces;

public interface IUserService
{
    Task<UserInfoDTO> GetUserInfoByIdAsync(int id);

    Task<List<UserInfoDTO>> GetUsersInfoAsync();

    Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model);

    Task<AuthenticateResponse?> RegisterAsync(UserDTO userModel);
}
