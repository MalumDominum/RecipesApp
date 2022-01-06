using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) { _service = service; }

        // POST: api/Users/authenticate
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest model)
        {
            var response = await _service.AuthenticateAsync(model);

            if (response == null)
                return BadRequest("Username or password is incorrect");

            return Ok(response);
        }

        // POST: api/Users/register
        [HttpPost("register")]
        public async Task<ActionResult<AuthenticateResponse>> Register(UserDTO user)
        {
            var response = await _service.RegisterAsync(user);

            if (response == null)
                return BadRequest("Didn't register!");

            return Ok(response);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserInfoDTO>>> GetUsersInfo()
        {
            return Ok(await _service.GetUsersInfoAsync());
        }

        // GET: api/Users/3
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserInfoDTO>> GetUserInfoById(int userId)
        {
            return Ok(await _service.GetUserInfoByIdAsync(userId));
        }
    }
}
