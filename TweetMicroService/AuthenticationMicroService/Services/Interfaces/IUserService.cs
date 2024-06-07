using AuthenticationMicroService.Models;

namespace AuthenticationMicroService.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}
