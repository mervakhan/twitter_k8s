using AuthenticationMicroService.Models;
using AuthenticationMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _userService.Authenticate(user.Username, user.Password);
            if (authenticatedUser == null)
                return Unauthorized();

            var token = _userService.GenerateJwtToken(authenticatedUser);
            return Ok(new { Token = token });
        }

        [HttpPost("signup")]
        public HttpResponseMessage SignUp([FromBody] User user)
        {
            return _userService.SignUp(user);
        }
    }
}
