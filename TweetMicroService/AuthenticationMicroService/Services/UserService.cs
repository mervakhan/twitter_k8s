using AuthenticationMicroService.DbContexts;
using AuthenticationMicroService.Models;
using AuthenticationMicroService.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationMicroService.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        private string _secretKey = "kweeterOAuthSecretKey!!!Secret~~!!!Key***";

        public User Authenticate(string username, string password)
        {
            var user = _userContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
                return null;

            // Authentication successful, return user without password
            user.Password = null;
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}