using DataAccessLayer.Models;

namespace BusinessLogicLayer.DTOs
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Token = token;
        }
    }
}
