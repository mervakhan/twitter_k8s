using AuthenticationMicroService.DbContexts;
using AuthenticationMicroService.Models;
using AuthenticationMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
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
            var claims = new[]
            {
                new Claim("UserId", user.ID.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public HttpResponseMessage SignUp(User user)
        {
            if(user.Password.Length < 8)
            {
                return CreateResponseMessage(HttpStatusCode.NotAcceptable, "Password length must be 8 charaters or more");
            }
            var existingUser = _userContext.Users.SingleOrDefault(u => u.Username == user.Username);
            if(existingUser != null)
            {
                return CreateResponseMessage(HttpStatusCode.NotAcceptable, "User already exists!");
            }
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return CreateResponseMessage(HttpStatusCode.Created, "User created successfully");
        }

        private HttpResponseMessage CreateResponseMessage(HttpStatusCode code, string message)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }
    }
}