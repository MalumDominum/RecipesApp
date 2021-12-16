using DataAccessLayer.Models;
using DataAccessLayer;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    //public class UserService : IUserService
    //{
    //    private readonly IUnitOfWork _unitOfWork;

    //    public UserService(IUoWFactory uowFactory)
    //    {
    //        _unitOfWork = uowFactory.CreateUoW();
    //    }

    //    public async Task<List<UserDTO>> GetUsersAsync()
    //    {
    //        return await _unitOfWork.Users.GetAllAsync();
    //    }

    //    public async Task<UserDTO> GetUserByIdAsync(int id)
    //    {
    //        return _unitOfWork.GetById(id);
    //    }

    //    public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
    //    {
    //        var user = _unitOfWork
    //            .GetAll()
    //            .FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

    //        if (user == null)
    //        {
    //            // todo: need to add logger
    //            return null;
    //        }

    //        var token = _configuration.GenerateJwtToken(user);

    //        return new AuthenticateResponse(user, token);
    //    }

    //    public async Task<Task<AuthenticateResponse>> RegisterAsync(UserDTO userModel)
    //    {
    //        var user = _mapper.Map<User>(userModel);

    //        var addedUser = await _unitOfWork.Add(user);

    //        var response = Authenticate(new AuthenticateRequest
    //        {
    //            Username = user.Username,
    //            Password = user.Password
    //        });

    //        return response;
    //    }
    //}
}
