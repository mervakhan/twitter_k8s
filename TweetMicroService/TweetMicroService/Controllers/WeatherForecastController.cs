using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TweetMicroService.DbContexts;
using TweetMicroService.Entities;

namespace TweetMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly UserContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            var UserId = _context.Users.FirstOrDefault().Id;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Updated2"+ Summaries[Random.Shared.Next(Summaries.Length)],
                UserId = UserId
            })
            .ToArray();
        }
    }
}
